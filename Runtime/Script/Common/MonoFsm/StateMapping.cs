/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using System.Collections;
using UnityEngine;

namespace BlackFire.Unity
{
    /// <summary>
    /// 状态映射。
    /// </summary>
    public class StateMapping
    {
        public object state;

        public bool HasEnterRoutine;
        public Action EnterCall = MonoFsmRunner.DoNothing;
        public Func<IEnumerator> EnterRoutine = MonoFsmRunner.DoNothingCoroutine;

        public bool HasExitRoutine;
        public Action ExitCall = MonoFsmRunner.DoNothing;
        public Func<IEnumerator> ExitRoutine = MonoFsmRunner.DoNothingCoroutine;

        public Action Finally = MonoFsmRunner.DoNothing;
        public Action Update = MonoFsmRunner.DoNothing;
        public Action LateUpdate = MonoFsmRunner.DoNothing;
        public Action FixedUpdate = MonoFsmRunner.DoNothing;
        public Action<Collision> OnCollisionEnter = MonoFsmRunner.DoNothingCollision;

        public StateMapping(object state)
        {
            this.state = state;
        }

    }
}
