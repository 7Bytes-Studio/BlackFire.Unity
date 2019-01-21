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
    public abstract class EditorWindowBase<T>: EditorWindow where T: EditorWindow
    {
        public static T Open(string title,float x,float y,float w,float h)
        {
            var window = EditorWindow.GetWindow(typeof(T), false, title) as T;
            window.position = new Rect(x,y,w,h);
            return window;
        }

        private void OnGUI()
        {
            OnDrawWindow();
        }

        protected abstract void OnDrawWindow();

    }
}
