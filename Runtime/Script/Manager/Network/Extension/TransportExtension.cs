/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Text;
using BlackFire.Unity.Network;

namespace BlackFire.Unity
{
    public static class TransportExtension 
	{
        /// <summary>
        /// 自定义编码发送数据。
        /// </summary>
        public static void Send(this TransportBase transportBase,string message, Encoding encoding)
        {
            var bytes = encoding.GetBytes(message);
            transportBase.Send(bytes);
        }

        /// <summary>
        /// 发送数据。(默认UTF-8编码)
        /// </summary>
        public static void Send(this TransportBase transportBase, string message)
        {
            var bytes = Encoding.UTF8.GetBytes(message);
            transportBase.Send(bytes);
        }

    }
}
