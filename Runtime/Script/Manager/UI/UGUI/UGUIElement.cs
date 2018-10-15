/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using UnityEngine;

namespace BlackFire.Unity
{
    /// <summary>
    /// UGUI的UI元素类。
    /// </summary>
    public class UGUIElement : UGUIForm , ILogic
    {
        public override ILogic Logic
        {
            get { return this; }
        }
  
        public void BubblingEvent<T>(Action<T> callback) 
        {
            var current = transform;
            UGUIForm form = null;
            T i = default(T);
            while (null!=current)
            {
                i = current.GetComponent<T>();
                if (null!=i)
                {
                    callback.Invoke(i);
                    return;
                }

                form = current.GetComponent<UGUIForm>();
                if (null!=form)
                {
                    if (form.Logic is T)
                    {
                        callback.Invoke((T)form.Logic);
                        return;
                    }
                }
                current = current.parent;
            }
        }
    }
}