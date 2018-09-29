//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

namespace BlackFire.Unity
{
    public class FormGroupMember : Organize.GroupMember
    {
        
        public Form Form { get; internal set; }


        
        protected override bool HandleCommand<T>(Organize.CommandCallback<T> commandCallback)
        {
            Log.Info(null!=Form && Form is T);
            Log.Info(null!=Form && Form is LogicalForm && (Form as LogicalForm).Logic is T);
            
            if (null!=Form && Form is T)
            {
                commandCallback.Invoke((T)(object)Form);
                return true;
            }

            if (null!=Form && Form is LogicalForm && (Form as LogicalForm).Logic is T)
            {                
                commandCallback.Invoke((T)(object)(Form as LogicalForm).Logic);
                return true;
            }
            
            return false;
        }
    }
}