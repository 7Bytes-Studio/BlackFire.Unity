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
    /// <summary>
    /// MessageBox模板。
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class MessageBoxTemplate : Template
    {
        public UnityEngine.UI.Button Confirm;
        public UnityEngine.UI.Button Cancel;
        public UnityEngine.UI.Text HeaderText;
        public UnityEngine.UI.Text ContentText;
        
        private CanvasGroup m_CanvasGroup;
        public CanvasGroup CanvasGroup
        {
            get 
            { 
                return m_CanvasGroup??(m_CanvasGroup=GetComponent<CanvasGroup>());
            }
        }

        private MessageBox MessageBox
        {
            get { return Owner as MessageBox; }
        }

        private void Awake()
        {
            Confirm.onClick.AddListener(() => { MessageBox.OnConfirmButtonClick(); });
            Cancel.onClick.AddListener(() => { MessageBox.OnCancelButtonClick(); });
        }
    }
}