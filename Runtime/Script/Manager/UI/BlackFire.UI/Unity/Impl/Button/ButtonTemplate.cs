/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

namespace BlackFire.UI
{
    /// <summary>
    /// Button模板。
    /// </summary>
    public class ButtonTemplate : Template
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

        protected virtual void Awake()
        {
            Button.onClick.AddListener(() =>
            {
                (Owner as Button).OnButtonClick();
            });
        }
    }
}