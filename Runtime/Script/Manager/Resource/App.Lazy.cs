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
        private static IResourceManager s_Resource = null;

        public static IResourceManager Resource
        {
            get { return s_Resource = (s_Resource ?? GetManager<IResourceManager>()); }
        }
    }
}