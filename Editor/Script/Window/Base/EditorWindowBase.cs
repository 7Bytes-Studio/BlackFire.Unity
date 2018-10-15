/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using UnityEditor;

namespace BlackFire.Unity.Editor
{
    public abstract class EditorWindowBase<T>: EditorWindow where T: EditorWindow
    {

        private void OnGUI()
        {
            OnDrawWindow();
        }

        protected abstract void OnDrawWindow();

    }
}
