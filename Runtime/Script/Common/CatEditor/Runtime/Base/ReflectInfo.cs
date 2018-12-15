/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using System.Reflection;

namespace CatEditor
{
    /// <summary>
    /// 反射信息基类。
    /// </summary>
    public abstract class ReflectInfo
    {
        /// <summary>
        /// 目标类型。
        /// </summary>
        public Type Type;

        /// <summary>
        /// 目标程序集。
        /// </summary>
        public Assembly Assembly;

        /// <summary>
        /// 实例。
        /// </summary>
        public object Instance;

    }
}