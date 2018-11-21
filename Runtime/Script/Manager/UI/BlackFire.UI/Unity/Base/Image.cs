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
    /// 图片。
    /// </summary>
    public abstract class Image : UnityUIElement
    {
        /// <summary>
        /// 颜色。
        /// </summary>
        public virtual Color Color
        {
            get { return Style.Color; }
            set
            {
                Style.Color = value;
                Appliy();
            }
        }
    }
}