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
    /// SpriteImage模板。
    /// </summary>
    public class SpriteImageTemplate : UITemplate,ISpriteImageTemplate
    {
        public UnityEngine.UI.Image SpriteImage;

        /// <summary>
        /// 精灵。
        /// </summary>
        public Sprite Sprite
        {
            get { return SpriteImage.sprite;}
            set { SpriteImage.sprite = value; }
        }

        /// <summary>
        /// 是否可交互。
        /// </summary>
        public bool Interactable
        {
            get
            {
                return SpriteImage.raycastTarget; 
            }
            set
            {
                SpriteImage.raycastTarget = value;
            }
        }

        /// <summary>
        /// 图片的颜色。
        /// </summary>
        public Color Color
        {
            get { return SpriteImage.color;}
            set { SpriteImage.color = value; }
        }
    }
}