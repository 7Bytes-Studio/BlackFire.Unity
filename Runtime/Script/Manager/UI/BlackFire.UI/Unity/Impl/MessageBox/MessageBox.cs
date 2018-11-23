/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;

namespace BlackFire.Unity
{
    /// <summary>
    /// MessageBox。
    /// </summary>
    public class MessageBox : HeaderedContentControl
    {
        private IMessageBoxTemplate MessageBoxTemplate
        {
            get { return Template as IMessageBoxTemplate; }
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
            get { return MessageBoxTemplate.Interactable;}
            set { MessageBoxTemplate.Interactable = value; }
        }

        public override void Show()
        {
            MessageBoxTemplate.Show(string.Empty,string.Empty);
            base.Show();
        }

        /// <summary>
        /// Message Box 的头部标题。
        /// </summary>
        public override string Header
        {
            get
            {
               return MessageBoxTemplate.Header;
            }
            set
            {
               MessageBoxTemplate.Header = value;
            }
        }
        
        /// <summary>
        /// 显示消息框。
        /// </summary>
        /// <param name="header">头部文本。</param>
        /// <param name="content">内容文本。</param>
        public void Show(string header,string content)
        {
            MessageBoxTemplate.Show(header,content);
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