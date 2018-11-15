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
    /// Label。
    /// </summary>
    public class Label : Text
    {        
        private LabelTemplate LabelTemplate
        {
            get { return Template as LabelTemplate; }
        }

        public string Content
        {
            get
            {
               return LabelTemplate.Label.text;
            }
            set
            {
                LabelTemplate.Label.text = value;
            }
        }

        public override void Show()
        {
            LabelTemplate.Label.gameObject.SetActive(true);
        }

        public override void Hide()
        {
            LabelTemplate.Label.gameObject.SetActive(false);
        }

        public override bool Interactable
        {
            get { return LabelTemplate.Label.raycastTarget;  }
            set { LabelTemplate.Label.raycastTarget = value; }
        }

        protected override void OnApply(Style style, Template template)
        {
            LabelTemplate.Label.color = style.Color;
        }
        
        
        
    }
}