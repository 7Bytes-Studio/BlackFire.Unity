/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using System.Collections.Generic;
using UnityEngine;

namespace BlackFire.Unity
{
    public sealed partial class App
    {
        private static BlackFire.Event.IEventHandler[] GetEventHandlersCallback(object root)
        {
            if (null != root)
            {
                List<BlackFire.Event.IEventHandler> list = new List<BlackFire.Event.IEventHandler>();
                Transform current = null;

                if (root is GameObject) current = (root as GameObject).transform;
                else if (root is Component) current = (root as Component).transform;
                else
                    return root is BlackFire.Event.IEventHandler
                        ? new BlackFire.Event.IEventHandler[] {root as BlackFire.Event.IEventHandler}
                        : null;

                while (null != current)
                {
                    var cmp = current.GetComponent<BlackFire.Event.IEventHandler>();
                    if (null != cmp)
                        list.Add(cmp);
                    current = current.parent;
                }

                return list.ToArray();
            }

            return null;
        }


        public static class Event
        {

            public static void Fire(string topicName, object sender, EventArgs eventArgs, bool fireNow = true)
            {
                BlackFire.Event.Fire(topicName,sender,eventArgs,fireNow);
            }


            public static void On(string topicName, object listener, EventHandler eventHandler)
            {
                BlackFire.Event.On(topicName,listener,eventHandler);
            }

            
            public static void Off(string topicName, object listener)
            {
                BlackFire.Event.Off(topicName,listener);
            }

            
            public static void On<T>(string topicName, object listener,EventHandler<T> eventHandler) where T:EventArgs
            {
                BlackFire.Event.On<T>(topicName,listener,eventHandler);
            }
            
            
            public static void Fire(object node,object sender,RoutedEventArgs args)
            {
                if (node is Visual)
                {
                    Fire(node as Visual,sender,args);
                }
                else if (node is Transform)
                {
                    Fire(node as Transform,sender,args);
                }
                else if (node is MonoBehaviour)
                {
                    Fire((node as MonoBehaviour).transform,sender,args);
                }
            }
            

            private static void Fire(Visual node,object sender,RoutedEventArgs args)
            {
                EventRouter.Fire(node,sender,args);
            }
            
            private static void Fire(Transform node,object sender,RoutedEventArgs args)
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

            private static void CallRoutedObjectMethodByTransform(Transform node,object sender,RoutedEventArgs args)
            {
                var rmbcs = node.GetComponents<RoutedMonoBehaviour>();
                if (null!=rmbcs)
                {
                    for (int i = 0; i < rmbcs.Length; i++)
                    {
                        rmbcs[i].OnRoutedEvents(sender,args);
                    }
                }
                
                var ruibcs = node.GetComponents<RoutedUIBehaviour>();
                if (null!=ruibcs)
                {
                    for (int i = 0; i < ruibcs.Length; i++)
                    {
                        ruibcs[i].OnRoutedEvents(sender,args);
                    }
                }
                
            }

            private static void FireTunnelEvent(Transform node,object sender,RoutedEventArgs args)
            {
                node.Traverse(n =>
                {
                    CallRoutedObjectMethodByTransform(n,sender,args);
                    return args.Handled;
                });
            }
        
            private static void FireBubbleEvent(Transform node,object sender,RoutedEventArgs args)
            {
                node.ReverseTraverse(n =>
                {
                    CallRoutedObjectMethodByTransform(n,sender,args);
                    return args.Handled;
                });
            }
        
            private static void FireDirectEvent(Transform node,object sender,RoutedEventArgs args)
            {
                CallRoutedObjectMethodByTransform(node,sender,args);
            }
            
            
        }


    }
}