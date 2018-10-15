/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;

namespace BlackFire.Unity
{
    /// <summary>
    /// 调试器参数。
    /// </summary>
    public sealed class DebuggerEventArgs : EventArgs 
	{
        /// <summary>
        /// 构造方法。
        /// </summary>
        /// <param name="args"></param>
        public DebuggerEventArgs(params object[] args)
        {
            Args = args;
        }

        /// <summary>
        /// 传递给内部方法的多个参数。
        /// </summary>
        public object[] Args { get; private set; }

	}
}
