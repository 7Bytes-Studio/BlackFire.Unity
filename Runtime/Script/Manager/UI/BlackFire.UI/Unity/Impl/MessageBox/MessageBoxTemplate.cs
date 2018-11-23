/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using UnityEngine;

namespace BlackFire.Unity
{
    /// <summary>
    /// MessageBox模板。
    /// </summary>
    [RequireComponent(typeof(CanvasGroup))]
    public class MessageBoxTemplate : UITemplate,IMessageBoxTemplate
    {
        public UnityEngine.UI.Button Confirm;
        public UnityEngine.UI.Button Cancel;
        public UnityEngine.UI.Text HeaderText;
        public UnityEngine.UI.Text ContentText;
        
        private CanvasGroup m_CanvasGroup;
        /// <summary>
        /// CanvasGroup组件引用。
        /// </summary>
        public CanvasGroup CanvasGroup
        {
            get 
            { 
                return m_CanvasGroup??(m_CanvasGroup=GetComponent<CanvasGroup>());
            }
        }

        /// <summary>
        /// 是否可交互。
        /// </summary>
        public override bool Interactable
        {
            get { return CanvasGroup.interactable; }
            set { CanvasGroup.interactable = value; }
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

        /// <summary>
        /// 显示消息框。
        /// </summary>
        /// <param name="header">头部文本。</param>
        /// <param name="content">内容文本。</param>
        public void Show(string header, string content)
        {
            HeaderText.text = header;
            ContentText.text = content;
        }

        /// <summary>
        /// Message Box的头部标题。
        /// </summary>
        public string Header
        {
            get { return HeaderText.text;}
            set { HeaderText.text = value; }
        }
    }
}