/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/


using UnityEditor;
using UnityEngine;

namespace BlackFire.Unity.Editor
{
    public static class BlackFireEditor
	{
        #region Path

        /// <summary>
        /// 框架资源路径。
        /// </summary>
        public static string BlackFireFrameworkPath { get; private set; }

        /// <summary>
        /// 框架内部资源路径。
        /// </summary>
        public static string AssetsPath = BlackFireFrameworkPath+"/.Assets/";
		
		/// <summary>
		/// 框架内部资源脚本模板路径。
		/// </summary>
		public static string ScriptTemplatePath
		{
			get { return Application.dataPath.Replace("-6:|      ").TrimEnd() + BlackFireFrameworkPath + "/.Assets/Data/Resources/ScriptTemplates/"; }
		}

		/// <summary>
		/// 框架内部Plugins路径。
		/// </summary>
		public static string PluginsPath
		{
			get { return Application.dataPath.Replace("-6:|      ").TrimEnd() + BlackFireFrameworkPath + "/.Assets/Plugins/"; }
		}
		
	    /// <summary>
	    /// 图片资源路径。
	    /// </summary>
	    public static string ImagesPath
	    {
		    get { return Application.dataPath.Replace("-6:|      ").TrimEnd() + BlackFireFrameworkPath + "/.Assets/Data/Resources/Images/"; }
	    }
		
		/// <summary>
		/// 图片资源路径。
		/// </summary>
		public static string EditorResourcesPath
		{
			get { return BlackFireFrameworkPath + "/Editor/EditorResources/"; }
		}
		
        /// <summary>
        /// 框架内部临时文件夹路径。
        /// </summary>
        public static string TempPath { get { return Application.dataPath + "/../Temp/BlackFireFramework.Temp/"; } }
        /// <summary>
        /// 框架内部临时包管理路径。
        /// </summary>
        public static string PackageTempPath { get { return TempPath+"Packages/"; } }
        /// <summary>
        /// 框架内部包管理路径。
        /// </summary>
        public static string PackagePath { get { return BlackFireFrameworkPath+"/Custom/Packages/"; } }
        /// <summary>
        /// 框架自定义二次开发资源路径。
        /// </summary>
        public static string FrameworkCustomPath { get { return BlackFireFrameworkPath+"/Custom/"; } }
        /// <summary>
        /// 框架自定义二次开发资源的相对路径。
        /// </summary>
        public static string FrameworkCustomRelativePath { get { return BlackFireFrameworkPath+"/Custom/"; } }



        #endregion

        [InitializeOnLoadMethod]
        private static void Init()
        {       
            InitFolders();
        }


        private static void InitFolders()
        {
            BlackFireFrameworkPath = DepthMatchingBlackFireFrameworkPath(); //初始化框架路径。
//            MakeUserCustomFolder();
//            MakeUserTempFolder();
        }

        private static void MakeUserCustomFolder()
        {
            var results = AssetDatabase.FindAssets("Custom");
            if (0 == results.Length)
            {
	            BlackFire.Utility.IO.ExistsOrCreateFolder(Application.dataPath + "/BlackFireFramework/Custom");
	            BlackFire.Utility.IO.ExistsOrCreateFolder(Application.dataPath + "/BlackFireFramework/Custom/Packages");
                AssetDatabase.Refresh();
            }
        }
        private static void MakeUserTempFolder()
        {
            BlackFire.Utility.IO.ExistsOrCreateFolder(Application.dataPath + "/../Temp/BlackFireFramework.Temp");
            BlackFire.Utility.IO.ExistsOrCreateFolder(Application.dataPath + "/../Temp/BlackFireFramework.Temp/Packages");
        }




        #region FrameworkAssetsPath //暂时无用。


        public static string FrameworkAssetsPath { get { return DepthMatchingFrameworkAssetsPath(); } }

        private static string DepthMatchingFrameworkAssetsPath()
        {

            var results = AssetDatabase.FindAssets("FrameworkInfo");
            foreach (var guid in results)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                if (path.Contains("BlackFireFramework") && path.Contains("Runtime") && path.Contains("Script")) //匹配第一个
                {
                    return path.Replace("/Runtime/Script/FrameworkInfo.cs", string.Empty);
                }
            }
            return string.Empty;

        }


        #endregion

        #region BlackFireFrameworkPath

        private static string DepthMatchingBlackFireFrameworkPath()
        {

            var results = AssetDatabase.FindAssets("App");
            foreach (var guid in results)
            {
                var path = AssetDatabase.GUIDToAssetPath(guid);
                if (path.Contains("Runtime") && path.Contains("Script")) //匹配第一个
                {
                    return path.Replace("/Runtime/Script/App.cs", string.Empty);
                }
            }
            return string.Empty;

        }


        #endregion

	    #region EditorResources

	    public static T Load<T>(string assetName) where T : UnityEngine.Object
	    {
		    return AssetDatabase.LoadAssetAtPath<T>(BlackFireEditor.EditorResourcesPath + assetName);
	    }

	    #endregion

    }
}
