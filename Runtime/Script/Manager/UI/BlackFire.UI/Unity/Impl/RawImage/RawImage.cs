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
    /// RawImage。
    /// </summary>
    public class RawImage : Image
    {
        private RawImageTemplate RawImageTemplate
        {
            get { return Template as RawImageTemplate; }
        }

        public virtual Texture Texture 
        {
            get { return RawImageTemplate.RawImage.texture; }
            set { RawImageTemplate.RawImage.texture = value; }
        }

        public override void Show()
        {
            RawImageTemplate.RawImage.gameObject.SetActive(true);
        }

        public override void Hide()
        {
            RawImageTemplate.RawImage.gameObject.SetActive(false);
        }

        public override bool Interactable
        {
            get
            {
               return RawImageTemplate.RawImage.raycastTarget;
            }
            set
            {
                RawImageTemplate.RawImage.raycastTarget = value;
            }
        }

        protected override void OnApply(Style style, Template template)
        {
            RawImageTemplate.RawImage.color = style.Color;
        }
    }
}