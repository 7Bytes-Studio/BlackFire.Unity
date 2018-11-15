/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;

namespace BlackFire.UI
{
    /// <summary>
    /// 路由事件参数。
    /// </summary>
    public class RoutedEventArgs : EventArgs
    {
        /// <summary>
        /// 路由事件。
        /// </summary>
        public RoutedEvent RoutedEvent;
        
        /// <summary>
        /// 标志事件是否被处理。
        /// </summary>
        public bool Handled;

        /// <summary>
        /// 触发事件的源对象。
        /// </summary>
        public object Source;

        /// <summary>
        /// 触发事件最初始的源对象。
        /// </summary>
        public object OriginalSource;
        
    }
}