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
    /// UI模板。
    /// </summary>
    public interface IUITemplate : ILogic
    {
        /// <summary>
        /// 模板的持有者。
        /// </summary>
        UnityUIElement Owner { get; set; }

        /// <summary>
        /// 显示模板。
        /// </summary>
        void Show();

        /// <summary>
        /// 隐藏模板。
        /// </summary>
        void Hide();
        
        /// <summary>
        /// 是否可交互。
        /// </summary>
        bool Interactable { get; set; }
    }
}