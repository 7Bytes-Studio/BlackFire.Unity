/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

namespace BlackFire.Unity
{
    /// <summary>
    /// BlackFire Framework 功能管家接口。
    /// </summary>
    public interface IManager 
	{
        /// <summary>
        /// 是否可用。
        /// </summary>
        bool IsWorking { get; }

        /// <summary>
        /// 启动管家。
        /// </summary>
        void StartManager();

        /// <summary>
        /// 关闭管家。
        /// </summary>
        void ShutdownManager();
	}

}
