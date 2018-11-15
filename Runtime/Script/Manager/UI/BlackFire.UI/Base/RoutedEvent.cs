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
    /// 路由事件。
    /// </summary>
    public sealed class RoutedEvent
    {
        public string Name;
        public Type HandlerType;
        public Type OwnerType;

        public RoutedEvent AddOwner(Type ownerType)
        {
            throw new NotImplementedException();
        }
    }
}