/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using UnityEngine;

namespace BlackFire.Unity
{
    /// <summary>
    /// Unity可回收对象的实现类。
    /// </summary>
    /// <typeparam name="T">对象类型。</typeparam>
	public abstract class UnityObject<T> : ObjectPool.ObjectBase where T : Object
    {
        /// <summary>
        /// 构造方法。
        /// </summary>
        /// <param name="target">目标对象实例。</param>
        public UnityObject(T target)
        {
            Target = target;
        }

        /// <summary>
        /// 目标对象实例。
        /// </summary>
        public T Target { get; private set; }

        /// <summary>
        /// 对象被回收事件。
        /// </summary>
        protected override void OnRelease()
        {
            base.OnRelease();
            GameObject.DestroyImmediate(Target);
        }

    }
}
