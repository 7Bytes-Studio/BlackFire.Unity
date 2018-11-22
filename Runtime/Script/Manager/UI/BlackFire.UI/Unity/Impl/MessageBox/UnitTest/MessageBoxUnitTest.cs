/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using UnityEngine;

namespace BlackFire.Unity
{
    public class MessageBoxUnitTest : MonoBehaviour
    {
        [SerializeField] private Asset m_MessageBoxTemplate;
        private MessageBox m_MessageBox;
        private void Start()
        {
            var msgbox = Instantiate(m_MessageBoxTemplate,transform);
            
            m_MessageBox = new MessageBox();
            m_MessageBox.Template=msgbox.GetLogic() as IMessageBoxTemplate; 
            m_MessageBox.OnConfirm += (object sender, EventArgs args) => { Debug.Log("OnConfirm");  };
            m_MessageBox.OnCancel  += (object sender, EventArgs args) => { Debug.Log("OnCancel");   };
            m_MessageBox.Hide();
        }
  
        private void OnGUI()
        {
            if (GUILayout.Button("Show MessageBox Ver1"))
            {
                m_MessageBox.Show("系统提示","人品值不足，请及时充值！");
            }
            
            if (GUILayout.Button("Show MessageBox Ver2"))
            {
                m_MessageBox.Show("东北人提示","瞅啥瞅！");
            }
            
            if (GUILayout.Button("Hide MessageBox"))
            {
                m_MessageBox.Hide();
            }
        }
    }
}