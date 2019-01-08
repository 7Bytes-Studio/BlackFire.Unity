/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using System.IO;
using UnityEditor;
using UnityEngine;

namespace BlackFire.Unity.Editor
{
    public class MessageBoxWindow : EditorWindowBase<MessageBoxWindow>
    {
        public static MessageBoxWindow Show(string title,string content,Color contentColor)
        {
            var window = EditorWindow.GetWindow(typeof(MessageBoxWindow), true, title) as MessageBoxWindow;
            window.position = new Rect(860f,510f,381,132f);
            window.Content = content;
            window.m_ContentColor = contentColor;
            return window;
        }
        
        public static MessageBoxWindow Show(string title,Action contentCallback)
        {
            var window = EditorWindow.GetWindow(typeof(MessageBoxWindow), true, title) as MessageBoxWindow;
            window.position = new Rect(860f,510f,381,132f);
            window.ContentCallback = contentCallback;
            return window;
        }

        private string Content;
        
        private Action ContentCallback;

        private Vector2 m_ScrollPosition;

        private Color m_ContentColor;

        protected override void OnDrawWindow()
        {
            if (null!=ContentCallback)
            {
                DrawContentCallbnack();
            }
            else
            {
                DrawContent();
            }
        }


        protected virtual void DrawContent()
        {
            m_ScrollPosition = GUILayout.BeginScrollView(m_ScrollPosition);
            {
                BlackFireEditorGUI.VerticalLayout(() => {

                    BlackFireEditorGUI.Label(Content, m_ContentColor,18);

                });
            }
            GUILayout.EndScrollView();
        }
        
        protected virtual void DrawContentCallbnack()
        {
            BlackFireEditorGUI.Space(7);
            m_ScrollPosition = GUILayout.BeginScrollView(m_ScrollPosition);
            {
                BlackFireEditorGUI.VerticalLayout(() => {

                    ContentCallback.Invoke();
                });
            }
            GUILayout.EndScrollView();
        }


    }

}
