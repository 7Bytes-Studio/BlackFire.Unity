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
    /// 带标题的条目控件。
    /// </summary>
    public abstract class HeaderedItemsControl : ItemsControl
    {
        /// <summary>
        /// 头标题。
        /// </summary>
        public abstract string Header { get; set; }
    }
}