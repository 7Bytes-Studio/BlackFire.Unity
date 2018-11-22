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
    /// Button模板接口。
    /// </summary>
    public interface IButtonTemplate:IUITemplate
    {
        /// <summary>
        /// 按钮的内容。
        /// </summary>
        string Content { get; set; }

        /// <summary>
        /// 是否可交互。
        /// </summary>
        bool Interactable { get; set; }
    }
}