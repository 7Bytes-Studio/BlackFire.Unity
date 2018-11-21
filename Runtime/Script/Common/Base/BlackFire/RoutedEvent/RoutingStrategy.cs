/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

namespace BlackFire
{
    /// <summary>
    /// 路由事件策略。
    /// </summary>
    public enum RoutingStrategy
    {
        /// <summary>
        /// 路由事件使用隧道策略，以便事件实例通过树向下路由（从根到源元素）。
        /// </summary>
        Tunnel = 0,
        
        /// <summary>
        /// 路由事件使用冒泡策略，以便事件实例通过树向上路由（从事件元素到根）。
        /// </summary>
        Bubble = 1,
        
        /// <summary>
        /// 路由事件不通过元素树路由。
        /// </summary>
        Direct = 2
    }
}