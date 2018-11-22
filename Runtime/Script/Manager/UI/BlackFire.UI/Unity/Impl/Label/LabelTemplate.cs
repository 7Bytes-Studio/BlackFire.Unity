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
    /// Label模板。
    /// </summary>
    public class LabelTemplate : UITemplate,ILabelTemplate
    {
        public UnityEngine.UI.Text Label;

        /// <summary>
        /// 按钮的内容。
        /// </summary>
        public string Content
        {
            get { return Label.text; }

            set { Label.text = value; }
        }

        /// <summary>
        /// 是否可交互。
        /// </summary>
        public bool Interactable
        {
            get { return Label.raycastTarget;}
            set { Label.raycastTarget = value; }
        }
    }
}