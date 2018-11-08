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
    /// MB驱动的状态机接口。
    /// </summary>
    public interface IMonoFsm
    {
        /// <summary>
        /// 状态机的Runner。
        /// </summary>
        MonoBehaviour Component { get; }

        /// <summary>
        /// 当前的状态映射数据结构。
        /// </summary>
        StateMapping CurrentStateMap { get; }

        /// <summary>
        /// 是否正在转移状态。
        /// </summary>
        bool IsInTransition { get; }

    }

    /// <summary>
    /// MB驱动的状态机接口。
    /// </summary>
    /// <typeparam name="T">状态枚举类型。</typeparam>
    public interface IMonoFsm<T> : IMonoFsm where T : struct, IConvertible, IComparable
    {
        /// <summary>
        /// 状态机状态的改变事件。
        /// </summary>
        event Action<T> OnFSMStateChangedEventHandler;

        /// <summary>
        /// 当前状态。
        /// </summary>
        T State { get; }
       
        /// <summary>
        /// 上一次的状态。
        /// </summary>
        T LastState{get;}

        /// <summary>
        /// 改变状态的状态。
        /// </summary>
        /// <param name="newState">新的状态。</param>
        void ChangeState(T newState);

        /// <summary>
        /// 改变状态的状态。
        /// </summary>
        /// <param name="newState">改变状态的模式。</param>
        /// <param name="fsmStateTransitionOption">状态机转移前的设置选项。</param>
        void ChangeState(T newState, MonoFSMStateTransitionOption fsmStateTransitionOption);

    }



}
