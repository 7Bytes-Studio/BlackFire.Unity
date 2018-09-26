//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using UnityEngine;

namespace BlackFireFramework.Unity
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