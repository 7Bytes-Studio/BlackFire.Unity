/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

namespace BlackFire.Unity
{
    public sealed class DebuggerTemplateGUI //: IDebuggerModuleGUI
    {
        public int Priority
        {
            get
            {
                return 10;
            }
        }

        public string ModuleName
        {
            get
            {
                return "Template";
            }
        }


        public void OnInit(DebuggerManager debuggerManager)
        {
            
        }

        public void OnModuleGUI()
        {
            
        }

        public void OnDestroy()
        {

        }
    }
}
