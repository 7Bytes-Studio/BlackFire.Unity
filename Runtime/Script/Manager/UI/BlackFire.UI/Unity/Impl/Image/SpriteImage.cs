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
    /// SpriteImage。
    /// </summary>
    public class SpriteImage : Image
    {
        private SpriteImageTemplate SpriteImageTemplate
        {
            get { return Template as SpriteImageTemplate; }
        }

        public virtual Sprite Sprite 
        {
            get { return SpriteImageTemplate.SpriteImage.sprite; }
            set { SpriteImageTemplate.SpriteImage.sprite = value; }
        }

        public override void Show()
        {
            SpriteImageTemplate.SpriteImage.gameObject.SetActive(true);
        }

        public override void Hide()
        {
            SpriteImageTemplate.SpriteImage.gameObject.SetActive(false);
        }

        public override bool Interactable
        {
            get
            {
                return SpriteImageTemplate.SpriteImage.raycastTarget;
            }
            set
            {
                SpriteImageTemplate.SpriteImage.raycastTarget = value;
            }
        }

        protected override void OnApply(Style style, Template template)
        {
            SpriteImageTemplate.SpriteImage.color = style.Color;
        }
    }
}