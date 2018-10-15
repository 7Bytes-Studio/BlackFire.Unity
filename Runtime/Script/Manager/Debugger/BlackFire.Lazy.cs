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
    public sealed partial class App
    {
        private static IDebuggerManager s_Debugger = null;

        public static IDebuggerManager Debugger
        {
            get { return s_Debugger = (s_Debugger ?? GetManager<IDebuggerManager>()); }
        }
    }
}