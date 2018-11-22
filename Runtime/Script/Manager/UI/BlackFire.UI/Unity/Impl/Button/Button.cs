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
    /// Button。
    /// </summary>
    public class Button : ContentControl
    {
        private IButtonTemplate ButtonTemplate
        {
            get { return Template as IButtonTemplate; }
        }

        /// <summary>
        /// 是否可交互。
        /// </summary>
        public override bool Interactable
        {
            get { return ButtonTemplate.Interactable; }
            set { ButtonTemplate.Interactable = value; }
        }

        /// <summary>
        /// 按钮内容。
        /// </summary>
        public string Content {
            get { return ButtonTemplate.Content; }
        }

        /// <summary>
        /// 按钮被点击事件。
        /// </summary>
        public event EventHandler OnClick;

        
        internal void OnButtonClick()
        {
            if (null!=OnClick)
            {
                OnClick.Invoke(this, null);
            }
        }
    }
}