/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/


namespace BlackFire.Unity.Editor
{
    using System;
    using UnityEditor;
    using UnityEngine;

    public static partial class Utility
    {
        public static class Project
        {

#region GarfieldJiang

//Scriptwriter : https://github.com/GarfieldJiang
            public static void SaveProject()
            {
#if UNITY_5_5_OR_NEWER
                AssetDatabase.SaveAssets();
#else
                EditorApplication.SaveAssets();
#endif
                Debug.Log("[ProjectSaver.SaveProject] You've saved the project.");
            }

            public static void OpenDataPath()
            {
                OpenFolder(Application.dataPath);
            }

            public static void OpenPersistentDataPath()
            {
                OpenFolder(Application.persistentDataPath);
            }

            public static void OpenStreamingAssetsPath()
            {
                OpenFolder(Application.streamingAssetsPath);
            }

            public static void OpenTemporaryCachePath()
            {
                OpenFolder(Application.temporaryCachePath);
            }

            public static void OpenFolder(string folder)
            {
                folder = string.Format("\"{0}\"", folder);
                switch (Application.platform)
                {
                    case RuntimePlatform.WindowsEditor:
                        System.Diagnostics.Process.Start("Explorer.exe", folder.Replace('/', '\\'));
                        break;
                    case RuntimePlatform.OSXEditor:
                        System.Diagnostics.Process.Start("open", folder);
                        break;
                    default:
                        throw new NotSupportedException(
                            string.Format("Opening folder on '{0}' platform is not supported.", Application.platform.ToString()));
                }
            }
//Scriptwriter : https://github.com/GarfieldJiang
#endregion


#region Alan

            public static void OpenScriptAssemblies()
            {
                OpenFolder(Application.dataPath+"/../Library/ScriptAssemblies");
            }
            
            public static void OpenApplicationContentsPath()
            {
                OpenFolder(EditorApplication.applicationContentsPath);
            }

#endregion

        }
    }
}
