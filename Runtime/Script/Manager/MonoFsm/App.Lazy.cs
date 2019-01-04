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
        private static IMonoFsmManager s_MonoFsm = null;

        public static IMonoFsmManager MonoFsm
        {
            get { return s_MonoFsm = (s_MonoFsm ?? GetManager<IMonoFsmManager>()); }
        }
    }
}