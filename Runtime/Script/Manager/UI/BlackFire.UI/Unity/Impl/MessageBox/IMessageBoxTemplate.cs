/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;

namespace BlackFire.Unity
{
    public interface IMessageBoxTemplate:IUITemplate
    {
        /// <summary>
        /// 显示消息框。
        /// </summary>
        /// <param name="header">头部文本。</param>
        /// <param name="content">内容文本。</param>
        void Show(string header, string content);

        /// <summary>
        /// Message Box 的头部标题。
        /// </summary>
        string Header { get; set; }

    }
}