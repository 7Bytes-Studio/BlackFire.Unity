//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Net;

namespace BlackFire.Unity
{
    public class FormGroupMember : Organize.GroupMember
    {
        
        public Form Form { get; internal set; }


        
        protected override bool HandleCommand<T>(Organize.CommandCallback<T> commandCallback)
        {

            
            
            if (null==Form)
            {
                goto jump_return_false;
            }

            T @interface = default(T);
            
            if (Form is Asset)
            {
                var target = Form.GetComponent<LogicalForm>();
                if (null!=target)
                {
                    @interface=(T)(object)target;
                }
            }
            else if (Form is T)
            {
                @interface=(T)(object)Form;
            }
            else if (Form is LogicalForm && (Form as LogicalForm).Logic is T)
            {     
                @interface=(T)(object)(Form as LogicalForm).Logic;
            }


            if (null!=@interface)
            {
                commandCallback.Invoke(@interface);
                return true;
            }
            
jump_return_false:
            return false;
        }
    }
}