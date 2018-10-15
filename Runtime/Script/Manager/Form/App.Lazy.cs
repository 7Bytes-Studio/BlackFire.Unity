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
        private static IFormManager s_Form = null;

        public static IFormManager Form
        {
            get { return s_Form = (s_Form ?? GetManager<IFormManager>()); }
        }
    }
}