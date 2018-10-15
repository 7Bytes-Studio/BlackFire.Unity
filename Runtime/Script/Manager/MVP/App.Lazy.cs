﻿/*
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
        private static IMVPManager s_MVP = null;

        public static IMVPManager MVP
        {
            get { return s_MVP = (s_MVP ?? GetManager<IMVPManager>()); }
        }
    }
}