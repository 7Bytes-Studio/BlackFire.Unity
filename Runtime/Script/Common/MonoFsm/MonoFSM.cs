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
using System.Collections.Generic;
using System.Reflection;
using System.Runtime.CompilerServices;
using UnityEngine;
using Object = System.Object;

namespace BlackFire.Unity
{

    /// <summary>
    /// MB状态机的泛型实现。
    /// </summary>
    /// <typeparam name="T">目标类。</typeparam>
    public class MonoFsm<T> : IMonoFsm<T> where T : struct, IConvertible, IComparable
    {
        public event Action<T> OnFSMStateChangedEventHandler;

        private MonoFsmRunner engine;
        private MonoBehaviour component;
        private StateMapping lastState;
        private StateMapping currentState;
        private StateMapping destinationState;
        private Dictionary<object, StateMapping> stateLookup;
        //private readonly string[] ignoredNames = new[] { "add", "remove", "get", "set" };
        private bool isInTransition = false;
        private IEnumerator currentTransition;
        private IEnumerator exitRoutine;
        private IEnumerator enterRoutine;
        private IEnumerator queuedChange;

        public MonoFsm(MonoFsmRunner engine, MonoBehaviour component)
        {
            this.engine = engine;
            this.component = component;

            var values = Enum.GetValues(typeof(T));
            if (values.Length < 1) { throw new ArgumentException("必须至少定义一个枚举的，亲!"); }

            stateLookup = new Dictionary<object, StateMapping>();
            for (int i = 0; i < values.Length; i++)
            {
                var mapping = new StateMapping((Enum)values.GetValue(i));
                stateLookup.Add(mapping.state, mapping);
            }

            var currentType = component.GetType();
            List<MethodInfo> methods = new List<MethodInfo>();
            while (null!=currentType)
            {
                methods.AddRange(currentType.GetMethods(BindingFlags.Instance | BindingFlags.DeclaredOnly | BindingFlags.Public | BindingFlags.NonPublic));
                currentType = currentType.BaseType;
            }
            var separator = "_".ToCharArray();
            for (int i = 0; i < methods.Count; i++)
            {
                if (methods[i].GetCustomAttributes(typeof(CompilerGeneratedAttribute), true).Length != 0)
                {
                    continue;
                }

                var names = methods[i].Name.Split(separator);

                if (names.Length <= 1)
                {
                    continue;
                }

                Enum key;
                try
                {
                    key = (Enum)Enum.Parse(typeof(T), names[0]);
                }
                catch (ArgumentException)
                {
                    continue;
                }

                var targetState = stateLookup[key];

                switch (names[1])
                {
                    case "Enter":
                        if (methods[i].ReturnType == typeof(IEnumerator))
                        {
                            targetState.HasEnterRoutine = true;
                            targetState.EnterRoutine = CreateDelegate<Func<IEnumerator>>(methods[i], component);
                        }
                        else
                        {
                            targetState.HasEnterRoutine = false;
                            targetState.EnterCall = CreateDelegate<Action>(methods[i], component);
                        }
                        break;
                    case "Exit":
                        if (methods[i].ReturnType == typeof(IEnumerator))
                        {
                            targetState.HasExitRoutine = true;
                            targetState.ExitRoutine = CreateDelegate<Func<IEnumerator>>(methods[i], component);
                        }
                        else
                        {
                            targetState.HasExitRoutine = false;
                            targetState.ExitCall = CreateDelegate<Action>(methods[i], component);
                        }
                        break;
                    case "Finally":
                        targetState.Finally = CreateDelegate<Action>(methods[i], component);
                        break;
                    case "Update":
                        targetState.Update = CreateDelegate<Action>(methods[i], component);
                        break;
                    case "LateUpdate":
                        targetState.LateUpdate = CreateDelegate<Action>(methods[i], component);
                        break;
                    case "FixedUpdate":
                        targetState.FixedUpdate = CreateDelegate<Action>(methods[i], component);
                        break;
                    case "OnCollisionEnter":
                        targetState.OnCollisionEnter = CreateDelegate<Action<Collision>>(methods[i], component);
                        break;
                }
            }

            currentState = new StateMapping(null);
        }
        private V CreateDelegate<V>(MethodInfo method, Object target) where V : class
        {
            var ret = (Delegate.CreateDelegate(typeof(V), target, method) as V);

            if (ret == null)
            {
                throw new ArgumentException("创建委托失败: " + method.Name);
            }
            return ret;

        }
        public void ChangeState(T newState)
        {
            ChangeState(newState, MonoFSMStateTransitionOption.Safe);
        }
        public void ChangeState(T newState, MonoFSMStateTransitionOption transition)
        {
            if (stateLookup == null)
            {
                throw new Exception("没有配置状态机的状态，请调用Init方法进行初始化");
            }

            if (!stateLookup.ContainsKey(newState))
            {
                throw new Exception("没有定义<<" + newState.ToString() + ">>这个状态");
            }

            var nextState = stateLookup[newState];

            if (currentState == nextState) return;

            if (queuedChange != null)
            {
                engine.StopCoroutine(queuedChange);
                queuedChange = null;
            }

            switch (transition)
            {

                case MonoFSMStateTransitionOption.Safe:
                    if (isInTransition)
                    {
                        if (exitRoutine != null) 
                        {
                            destinationState = nextState;
                            return;
                        }

                        if (enterRoutine != null) 
                        {
                            queuedChange = WaitForPreviousTransition(nextState);
                            engine.StartCoroutine(queuedChange);
                            return;
                        }
                    }
                    break;
                case MonoFSMStateTransitionOption.Overwrite:
                    if (currentTransition != null)
                    {
                        engine.StopCoroutine(currentTransition);
                    }
                    if (exitRoutine != null)
                    {
                        engine.StopCoroutine(exitRoutine);
                    }
                    if (enterRoutine != null)
                    {
                        engine.StopCoroutine(enterRoutine);
                    }

                    break;
            }


            if ((currentState != null && currentState.HasExitRoutine) || nextState.HasEnterRoutine)
            {
                isInTransition = true;
                currentTransition = ChangeToNewStateRoutine(nextState, transition);
                engine.StartCoroutine(currentTransition);
            }
            else 
            {
                if (currentState != null)
                {
                    currentState.ExitCall();
                    currentState.Finally();
                }

                lastState = currentState;
                currentState = nextState;
                if (currentState != null)
                {
                    currentState.EnterCall();
                    if (OnFSMStateChangedEventHandler != null)
                    {
                        OnFSMStateChangedEventHandler((T)currentState.state);
                    }
                }
                isInTransition = false;
            }
        }
        private IEnumerator ChangeToNewStateRoutine(StateMapping newState, MonoFSMStateTransitionOption transition)
        {
            destinationState = newState;

            if (currentState != null)
            {
                if (currentState.HasExitRoutine)
                {
                    exitRoutine = currentState.ExitRoutine();

                    if (exitRoutine != null && transition != MonoFSMStateTransitionOption.Overwrite)
                    {
                        yield return engine.StartCoroutine(exitRoutine);
                    }

                    exitRoutine = null;
                }
                else
                {
                    currentState.ExitCall();
                }

                currentState.Finally();
            }

            lastState = currentState;
            currentState = destinationState;

            if (currentState != null)
            {
                if (currentState.HasEnterRoutine)
                {
                    enterRoutine = currentState.EnterRoutine();

                    if (enterRoutine != null)
                    {
                        yield return engine.StartCoroutine(enterRoutine);
                    }

                    enterRoutine = null;
                }
                else
                {
                    currentState.EnterCall();
                }

                if (OnFSMStateChangedEventHandler != null)
                {
                    OnFSMStateChangedEventHandler((T)currentState.state);
                }
            }

            isInTransition = false;
        }
        IEnumerator WaitForPreviousTransition(StateMapping nextState)
        {
            while (isInTransition)
            {
                yield return null;
            }

            ChangeState((T)nextState.state);
        }
        public T LastState
        {
            get
            {
                if (lastState == null) return default(T);

                return (T)lastState.state;
            }
        }
        public T State
        {
            get { return (T)currentState.state; }
        }
        public bool IsInTransition
        {
            get { return isInTransition; }
        }
        public StateMapping CurrentStateMap
        {
            get { return currentState; }
        }
        public MonoBehaviour Component
        {
            get { return component; }
        }
        public static MonoFsm<T> Init(MonoBehaviour component)
        {
            var engine = component.GetComponent<MonoFsmRunner>();
            if (engine == null) engine = component.gameObject.AddComponent<MonoFsmRunner>();

            return engine.Initialize<T>(component);
        }
        public static MonoFsm<T> Init(MonoBehaviour component, T startState)
        {
            var engine = component.GetComponent<MonoFsmRunner>();
            if (engine == null) engine = component.gameObject.AddComponent<MonoFsmRunner>();

            return engine.Initialize<T>(component, startState);
        }

    }

    /// <summary>
    /// 状态机转移选项。
    /// </summary>
    public enum MonoFSMStateTransitionOption
    {
        /// <summary>
        /// 安全的（协程安全）。
        /// </summary>
        Safe,
        /// <summary>
        /// 重写的。
        /// </summary>
        Overwrite,
    }
}
