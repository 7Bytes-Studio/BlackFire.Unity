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
    /// <summary>
    /// MonoFsm模式管家。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("BlackFire/Manager/MonoFsm")]
    public sealed class MonoFsmManager : ManagerBase,IMonoFsmManager
    {
        private Dictionary<MonoBehaviour, GameObject> m_Dic = new Dictionary<MonoBehaviour, GameObject>();
        public IMonoFsm<T> CreateMonoFsm<T>(MonoBehaviour fsmImplComponent) where T : struct, IConvertible, IComparable
        {
            IMonoFsm<T> ins = default(IMonoFsm<T>);
            ins = MonoFsm<T>.Init(fsmImplComponent);
            return ins;
        }
        
        public IMonoFsm<T> CreateMonoFsmStandalone<T>(MonoBehaviour fsmImplComponent) where T : struct, IConvertible, IComparable
        {
            IMonoFsm<T> ins = default(IMonoFsm<T>);
            var runner = new GameObject("FsmRunner : " + fsmImplComponent.name);
            runner.transform.SetParent(this.transform);
            SafeAdd(fsmImplComponent,runner);
            ins = MonoFsm<T>.Init(runner,fsmImplComponent);
            return ins;
        }

        private void SafeAdd(MonoBehaviour fsmImplComponent,GameObject runner)
        {
            if (!m_Dic.ContainsKey(fsmImplComponent))
            {
                m_Dic.Add(fsmImplComponent,runner);
            }
        }
        
        private void SafeRemove(MonoBehaviour fsmImplComponent)
        {
            if (m_Dic.ContainsKey(fsmImplComponent))
            {
                var runner = m_Dic[fsmImplComponent];
                m_Dic.Remove(fsmImplComponent);
                GameObject.DestroyImmediate(runner);
            }
        }

        public void DestroyMonoFsm(MonoBehaviour fsmImplComponent)
        {
            SafeRemove(fsmImplComponent);
        }


    }
}