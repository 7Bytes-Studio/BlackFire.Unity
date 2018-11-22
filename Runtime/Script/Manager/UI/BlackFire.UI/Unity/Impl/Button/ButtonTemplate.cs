/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

namespace BlackFire.Unity
{
    /// <summary>
    /// Button模板。
    /// </summary>
    public class ButtonTemplate : UITemplate, IButtonTemplate
    {
        public UnityEngine.UI.Button Button;

        /// <summary>
        /// 按钮的内容。
        /// </summary>
        public string Content
        {
            get
            {
                var text = Button.GetComponentInChildren<UnityEngine.UI.Text>(true);
                
                if (null!=text)
                {
                    return text.text;
                }
                return string.Empty;
            }

            set
            {
                var text = Button.GetComponentInChildren<UnityEngine.UI.Text>(true);
                if (null!=text)
                {
                    text.text = value;
                }
            }
        }

        /// <summary>
        /// 是否可交互。
        /// </summary>
        public override bool Interactable
        {
            get { return Button.interactable;}
            set { Button.interactable = value; }
        }

        protected virtual void Awake()
        {
            Button.onClick.AddListener(() =>
            {
                (Owner as Button).OnButtonClick();
            });
        }
    }
}