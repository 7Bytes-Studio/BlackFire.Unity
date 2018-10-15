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
    [AttributeUsage(AttributeTargets.Class,AllowMultiple = false)]
	public sealed class GameObjectIconAttribute : Attribute 
	{
        /// <summary>
        /// 构造方法
        /// </summary>
        /// <param name="iconPath">icon图片所在的资源路径(相对于Resources目录下的路径)。</param>
        public GameObjectIconAttribute(string iconPath)
        {
            IconPath = iconPath;
        }

        /// <summary>
        /// Icon资源所在的相对路径。
        /// </summary>
        public string IconPath { get; private set; }

	}
}
