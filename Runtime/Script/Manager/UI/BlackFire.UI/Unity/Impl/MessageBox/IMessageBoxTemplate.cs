using System;

namespace BlackFire.Unity
{
    public interface IMessageBoxTemplate:IUITemplate
    {
        /// <summary>
        /// 显示消息框。
        /// </summary>
        /// <param name="header">头部文本。</param>
        /// <param name="content">内容文本。</param>
        void Show(string header, string content);
    }
}