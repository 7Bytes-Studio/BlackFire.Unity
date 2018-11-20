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
    /// 事件路由。
    /// </summary>
    public static class EventRouter
    {

        /// <summary>
        /// 触发路由事件。
        /// </summary>
        /// <param name="node">元素树起始节点。</param>
        /// <param name="sender">发送者。</param>
        /// <param name="args">事件参数。</param>
        public static void Fire(Visual node,object sender,RoutedEventArgs args)
        {
            if(null!=args && null!=args.RoutedEvent)
                switch (args.RoutedEvent.RoutingStrategy)
                {
                    case RoutingStrategy.Tunnel :
                        FireTunnelEvent(node,sender,args);
                        break;
                    case RoutingStrategy.Bubble :
                        FireBubbleEvent(node,sender,args);
                        break;
                    default: FireDirectEvent(node,sender,args);
                        break;
                }   
        }


        private static void FireTunnelEvent(Visual node,object sender,RoutedEventArgs args)
        {
            Visual.Traverse(node, n =>
            {
                n.OnRoutedEvents(sender,args);
                return args.Handled;
            });
        }
        
        private static void FireBubbleEvent(Visual node,object sender,RoutedEventArgs args)
        {
            Visual.ReverseTraverse(node, n =>
            {
                n.OnRoutedEvents(sender,args);
                return args.Handled;
            });
        }
        
        private static void FireDirectEvent(Visual node,object sender,RoutedEventArgs args)
        {
            node.OnRoutedEvents(sender,args);
        }
        
    }
}