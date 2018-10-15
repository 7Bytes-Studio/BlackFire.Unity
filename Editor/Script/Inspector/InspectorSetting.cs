/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

namespace BlackFire.Unity.Editor
{
    /// <summary>
    /// Inspector的设置类。
    /// </summary>
    public sealed class InspectorSetting
    {
        /// <summary>
        /// 构造方法。
        /// </summary>
        /// <param name="drawDefaultGUI">是否同时绘制默认的GUI。</param>
        /// <param name="playingDrawing">是否在编辑器运行时进行渲染。</param>
        /// <param name="notPlayingDrawing">是否在编辑器不运行时进行渲染。</param>
        /// <param name="compilingDrawing">是否在编辑器编译时进行渲染。</param>
        public InspectorSetting(bool drawDefaultGUI=false,bool playingDrawing=true, bool notPlayingDrawing=true, bool compilingDrawing=true)
        {
            DrawDefaultGUI = drawDefaultGUI;
            PlayingDrawing = playingDrawing;
            NotPlayingDrawing = notPlayingDrawing;
            CompilingDrawing = compilingDrawing;
        }

        /// <summary>
        /// 是否同时绘制默认的GUI。
        /// </summary>
        public bool DrawDefaultGUI { get; private set; }

        /// <summary>
        /// 是否在编辑器运行时进行渲染。
        /// </summary>
        public bool PlayingDrawing { get; private set; }

        /// <summary>
        /// 是否在编辑器不运行时进行渲染。
        /// </summary>
        public bool NotPlayingDrawing { get; private set; }

        /// <summary>
        /// 是否在编辑器编译时进行渲染。
        /// </summary>
        public bool CompilingDrawing { get; private set; }
               
    }
}
