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
    /// SpriteImage。
    /// </summary>
    public class SpriteImage : Image
    {
        private ISpriteImageTemplate SpriteImageTemplate
        {
            get { return Template as ISpriteImageTemplate; }
        }

        public virtual Sprite Sprite 
        {
            get { return SpriteImageTemplate.Sprite; }
            set { SpriteImageTemplate.Sprite = value; }
        }

        public override void Show()
        {
            SpriteImageTemplate.Show();
        }

        public override void Hide()
        {
            SpriteImageTemplate.Hide();
        }

        public override bool Interactable
        {
            get
            {
                return SpriteImageTemplate.Interactable;
            }
            set
            {
                SpriteImageTemplate.Interactable = value;
            }
        }

        protected override void OnApply(Style style, IUITemplate template)
        {
            SpriteImageTemplate.Color = style.Color;
        }
    }
}