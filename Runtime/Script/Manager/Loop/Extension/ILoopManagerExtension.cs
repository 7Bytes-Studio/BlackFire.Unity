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
    /// LoopComponent扩展类。
    /// </summary>
    public static class ILoopManagerExtension
	{
        public static void Register(this ILoopManager loop, Action callback, LoopType loopType, string name = null)
        {
            loop.Register(callback as Delegate, loopType,name);
        }

        #region 测试
        //Not often used ... 

        public static void Register(this ILoopManager loop, Action<int> callback, LoopType loopType, string name = null)
        {
            loop.Register(callback as Delegate, loopType, name);
        }

        public static void Register(this ILoopManager loop, Action<int, int> callback, LoopType loopType, string name = null)
        {
            loop.Register(callback as Delegate, loopType, name);
        }

        //Not often used ...
        #endregion

    }
}
