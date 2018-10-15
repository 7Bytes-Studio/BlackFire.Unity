/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using UnityEngine;

namespace BlackFire.Unity
{
    public sealed partial class App
    {
        #region ExportedAssembly

        [SerializeField] private string[] m_AssemblyList;

        /// <summary>
        /// 被导出的程序集列表。
        /// </summary>
        public static string[] ExtendedAssemblies
        {
            get { return null != s_Instance ? s_Instance.m_AssemblyList : null; }
        }

        private static IExportedAssemblyManager m_ExportedAssemblyManager = null;

        private static void StartAssemblyManager(App instance)
        {
            m_ExportedAssemblyManager =
                (IExportedAssemblyManager) EntityTree.GetEntityInChildren(typeof(IExportedAssemblyManager));
            for (int i = 0; i < ExtendedAssemblies.Length; i++)
            {
                m_ExportedAssemblyManager.LoadExportedAssembly(ExtendedAssemblies[i]);
            }
        }

        private static void ShutdownAssemblyManager()
        {
            for (int i = 0; i < ExtendedAssemblies.Length; i++)
            {
                m_ExportedAssemblyManager.UnLoadExportAssembly(ExtendedAssemblies[i]);
            }
        }

        #endregion

    }
}