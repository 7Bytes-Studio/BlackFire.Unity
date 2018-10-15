/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

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
    }
}