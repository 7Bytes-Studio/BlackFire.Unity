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
        private static ILoopManager s_Loop = null;

        public static ILoopManager Loop
        {
            get { return s_Loop = (s_Loop ?? GetManager<ILoopManager>()); }
        }

    }
}