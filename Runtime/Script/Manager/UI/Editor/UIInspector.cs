/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using BlackFire.Unity;
using System;
using UnityEditor;
using UnityEngine;

namespace BlackFire.Unity.Editor
{
    [CustomEditor(typeof(UIManager))]
    [DisallowMultipleComponent]
    public sealed class UIInspector : InspectorBase
    {
        public override InspectorSetting Setting
        {
            get
            {
                return new InspectorSetting();
            }
        }

        //private UIManager m_UIManager = null;

        private SerializedProperty m_SP_IUIEventDataHelperTypeFullName = null;
  


        private Type[] m_ImplTypes = null;
        private int m_PopupIndex = 0;

        private void OnEnable()
        {
            
            //m_UIManager = target as UIManager;
            m_SP_IUIEventDataHelperTypeFullName = serializedObject.FindProperty("m_IUIEventDataHelperTypeFullName");
            var ac = BlackFire.Utility.Reflection.GetImplTypes("Assembly-CSharp", typeof(IUIEventDataHelper));
            var acf = BlackFire.Utility.Reflection.GetImplTypes("Assembly-CSharp-firstpass", typeof(IUIEventDataHelper));
            m_ImplTypes = new Type[ac.Length+acf.Length];
            int index = 0;
            for (int i = 0; i < ac.Length; i++)
            {
                m_ImplTypes[index++] = ac[i];
            }
            for (int i = 0; i < acf.Length; i++)
            {
                m_ImplTypes[index++] = acf[i];
            }
        }

        protected override void OnDrawInspector()
        {
            GUILayout.Space(15);
            DrawHelperPopup(m_ImplTypes);
        }

        private void DrawHelperPopup(Type[] implTypes)
        {
            string[] array = new string[implTypes.Length];
            for (int i = 0; i < m_ImplTypes.Length; i++)
            {
                array[i] = m_ImplTypes[i].FullName;
            }
            BlackFireEditorGUI.ArrayPopup("UIEventDataHelper", ref m_PopupIndex, array);
            m_SP_IUIEventDataHelperTypeFullName.stringValue = array[m_PopupIndex];
        }

    }
}
