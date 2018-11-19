/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;

namespace BlackFire.UI
{
    /// <summary>
    /// MessageBox。
    /// </summary>
    public class MessageBox : HeaderedContentControl
    {
        private MessageBoxTemplate MessageBoxTemplate
        {
            get { return Template as MessageBoxTemplate; }
        }

        /// <summary>
        /// 确定事件。
        /// </summary>
        public event EventHandler OnConfirm;
        
        /// <summary>
        /// 取消事件。
        /// </summary>
        public event EventHandler OnCancel;
        
        /// <summary>
        /// 是否可交互。
        /// </summary>
        public override bool Interactable
        {
            get { return MessageBoxTemplate.CanvasGroup.interactable;}
            set { MessageBoxTemplate.CanvasGroup.interactable = value; }
        }

        public override void Show()
        {
            MessageBoxTemplate.HeaderText.text = string.Empty;
            MessageBoxTemplate.ContentText.text = string.Empty;
            base.Show();
        }

        /// <summary>
        /// 显示消息框。
        /// </summary>
        /// <param name="header">头部文本。</param>
        /// <param name="content">内容文本。</param>
        public void Show(string header,string content)
        {
            MessageBoxTemplate.HeaderText.text = header;
            MessageBoxTemplate.ContentText.text = content;
            base.Show();
        }

        internal void OnConfirmButtonClick()
        {
            if (null!=OnConfirm)
            {
                OnConfirm.Invoke(this,null);
            }
        }

        internal void OnCancelButtonClick()
        {
            if (null!=OnCancel)
            {
                OnCancel.Invoke(this,null);
            }
        }
    }
}