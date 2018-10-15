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
    /// Debugger模块的GUI渲染接口。
    /// </summary>
    public interface IDebuggerModuleGUI
    {
        /// <summary>
        /// 在调试器上被绘制的优先级。
        /// </summary>
        int Priority { get; }

        /// <summary>
        /// Debugger模块的名字。
        /// </summary>
        string ModuleName { get; }

        /// <summary>
        /// Debugger模块初始化事件。
        /// </summary>
        /// <param name="debuggerManager"></param>
        void OnInit(DebuggerManager debuggerManager);

        /// <summary>
        /// Debugger模块的GUI被绘制事件。
        /// </summary>
        /// <param name="debuggerManager">调试器管家。</param>
        void OnModuleGUI();

        /// <summary>
        /// Debugger模块被销毁事件。
        /// </summary>
        void OnDestroy();

    }




}
