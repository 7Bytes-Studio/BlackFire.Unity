﻿/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using BlackFire.Unity;
using UnityEditor;
using UnityEngine;

namespace BlackFire.Unity.Editor
{
    [CustomEditor(typeof(Asset))]
    public sealed class AssetInspector : InspectorBase
    {
        public override InspectorSetting Setting
        {
            get
            {
                return new InspectorSetting(false,true,false,false);
            }
        }


        private void OnEnable()
        {

        }

        //private bool m_WindowInfoFoldOut = true;
        protected override void OnDrawInspector()
        {
            var asset = target as Asset;
            GUILayout.Space(15);
            BlackFireEditorGUI.BoxVerticalLayout(() => {
                if (!string.IsNullOrEmpty(asset.GroupName))
                {
                    BlackFireEditorGUI.HorizontalLayout(() => {
                        BlackFireEditorGUI.Label("Asset Info:");
                    });
                    BlackFireEditorGUI.HorizontalLayout(() => {
                        if (null != asset.GroupId)
                        {
                            BlackFireEditorGUI.Label(asset.ToString());
                        }
                    });
                }
                else
                {
                    EditorGUILayout.HelpBox("Asset is not defined!", MessageType.Info);
                }

            });



            //m_WindowInfoFoldOut = BlackFireEditorGUI.FoldOut("WindowInfo", m_WindowInfoFoldOut);
            //if (m_WindowInfoFoldOut)
            //{
            //    BlackFireEditorGUI.Label(uiWindow.ToString());
            //}
        }

    }
}
