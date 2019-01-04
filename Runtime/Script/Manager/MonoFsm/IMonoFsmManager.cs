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
    public interface IMonoFsmManager:IManager
    {
        IMonoFsm<T> CreateMonoFsm<T>(MonoBehaviour fsmImplComponent) where T : struct, IConvertible, IComparable;
    
        IMonoFsm<T> CreateMonoFsmStandalone<T>(MonoBehaviour fsmImplComponent) where T : struct, IConvertible, IComparable;

        void DestroyMonoFsm(MonoBehaviour fsmImplComponent);
    }
}