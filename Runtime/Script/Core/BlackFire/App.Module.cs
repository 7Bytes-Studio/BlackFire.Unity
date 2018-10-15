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
        #region Module

        private static IModuleManager s_ModuleManager = null;

        public static IModuleManager ModuleManager
        {
            get { return s_ModuleManager; }
        }

        private static void StartModuleManager(App instance)
        {
            if (null != instance)
            {
                s_ModuleManager = (IModuleManager) EntityTree.GetEntityInChildren(typeof(IModuleManager));
            }
        }

        #endregion
    }
}