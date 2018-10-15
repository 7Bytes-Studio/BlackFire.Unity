/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

// ScriptMainLogicWriter : https://github.com/Yawpp

using UnityEditor;
using UnityEditor.SceneManagement;
using UnityEngine;

namespace BlackFire.Unity.Editor
{
    public sealed class DevelopmentSceneWindow : EditorWindowBase<DevelopmentSceneWindow>
    {
        private static DevelopmentScene s_EditorScene;

        private void OnEnable()
        {
            if (null==s_EditorScene)
            {
                s_EditorScene = Resources.Load<DevelopmentScene>("DevelopmentScene");
            }
        }

        protected override void OnDrawWindow()
        {
            if (null!=s_EditorScene)
            {
                foreach (var item in s_EditorScene.Scenes)
                {
                    if (GUILayout.Button(item.name))
                    {
                        EditorSceneManager.OpenScene(AssetDatabase.GetAssetPath(item));
                    }
                }
            }
        }
    }
}