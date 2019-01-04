/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEditor;
using UnityEditor.ProjectWindowCallback;
using UnityEngine;

namespace BlackFire.Unity.Editor
{
    public static class AssetsMenu 
    {
//        [MenuItem("Assets/BlackFire/EditorWindowScript",false,0)]
//        public static void OnMenuItemClick()
//        {
//           ProjectWindowUtil.StartNameEditingIfProjectWindowExists(0,
//           ScriptableObject.CreateInstance<CreateEditorWindowScriptAsset>(),
//           "/New EditorWindowScript.cs",
//           null,
//           BlackFireEditor.ScriptTemplatePath+ "EditorWindowScriptTemplate.cs");
//           
//        }

        public static string GetSelectionAssetsPath()
        {
            Object[] arr = Selection.GetFiltered(typeof(Object), SelectionMode.TopLevel);
            return Application.dataPath.Substring(0, Application.dataPath.LastIndexOf('/')) + "/" + AssetDatabase.GetAssetPath(arr[0]);
        }


       

    }




}
