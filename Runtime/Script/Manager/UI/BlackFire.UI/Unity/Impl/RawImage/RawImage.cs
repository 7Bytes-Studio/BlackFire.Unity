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
    /// RawImage。
    /// </summary>
    public class RawImage : Image
    {
        private IRawImageTemplate RawImageTemplate
        {
            get { return Template as IRawImageTemplate; }
        }

        public virtual Texture Texture 
        {
            get { return RawImageTemplate.Texture; }
            set { RawImageTemplate.Texture = value; }
        }

        public override void Show()
        {
            RawImageTemplate.Show();
        }

        public override void Hide()
        {
            RawImageTemplate.Hide();
        }

        public override bool Interactable
        {
            get
            {
               return RawImageTemplate.Interactable;
            }
            set
            {
                RawImageTemplate.Interactable = value;
            }
        }

        protected override void OnApply(Style style, IUITemplate template)
        {
            RawImageTemplate.Color = style.Color;
        }
    }
}