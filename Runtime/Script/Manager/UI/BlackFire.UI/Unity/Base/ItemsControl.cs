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
    /// 条目控件。
    /// </summary>
    public abstract class ItemsControl : Control
    {
        private ItemCollection m_Items = new ItemCollection();
       
        /// <summary>
        /// 条目集合。
        /// </summary>
        public ItemCollection Items
        {
            get { return m_Items; }
        }
    }
}