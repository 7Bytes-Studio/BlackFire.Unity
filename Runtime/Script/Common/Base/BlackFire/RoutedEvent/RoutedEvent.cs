/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;

namespace BlackFire
{
    /// <summary>
    /// 路由事件。
    /// </summary>
    public sealed class RoutedEvent
    {
        public RoutedEvent(string name)
        {
            this.Name = name;
        }

        /// <summary>
        /// 路由名字。
        /// </summary>
        public string Name { get; private set; }

        /// <summary>
        /// 路由策略。
        /// </summary>
        public RoutingStrategy RoutingStrategy;

        /// <summary>
        /// 处理者类型。
        /// </summary>
        public Type HandlerType;
        
        /// <summary>
        /// 所属者类型。
        /// </summary>
        public Type OwnerType;

    }
}