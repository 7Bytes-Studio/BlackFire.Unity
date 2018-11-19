/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using UnityEngine;

namespace BlackFire.UI
{
    public class MessageBoxUnitTest : MonoBehaviour
    {
        private MessageBox m_MessageBox;
        private void Start()
        {
            m_MessageBox = new MessageBox();
            m_MessageBox.Template = GetComponentInChildren<MessageBoxTemplate>(true);
            m_MessageBox.Hide();
        }

        private void OnGUI()
        {
            if (GUILayout.Button("Show MessageBox"))
            {
                m_MessageBox.Show("系统提示","人品值不足，请及时充值！");
            }
        }
    }
}