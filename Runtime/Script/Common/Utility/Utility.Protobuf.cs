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
    public static partial class Utility
    {
        /// <summary>
        /// Protobuf助手类
        /// </summary>
        public static class Protobuf 
        {

            /// <summary>
            /// ProtobufHelper助手类的接口
            /// </summary>
            private static Utility.Protobuf.IProtobuf m_IProtobufHelper=null;

            /// <summary>
            /// 设置助手具体实现
            /// </summary>
            /// <param name="protobufHelper">具体实现</param>
            public static void SetProtobufImpl(Utility.Protobuf.IProtobuf protobufHelper)
            {
                m_IProtobufHelper = protobufHelper;
            }

            /// <summary>
            /// 序列化
            /// </summary>
            /// <typeparam name="T">需要序列化的协议类</typeparam>
            /// <param name="t_T">需要序列化的协议类的实例</param>
            /// <returns>序列化字节流</returns>
            public static byte[] Serialize<T>(T t_T)
            {
                return m_IProtobufHelper.Serialize(t_T);
            }
            
            /// <summary>
            /// 反序列化
            /// </summary>
            /// <typeparam name="T">需要反序列化的协议类</typeparam>
            /// <param name="t_Byte">字节流</param>
            /// <returns>反序列化的对象实例</returns>
            public static T DeSerialize<T>(byte[] t_Byte)
            {
                return m_IProtobufHelper.DeSerialize<T>(t_Byte);
            }                        
            
            /// <summary>
            /// Protobuf辅助类接口
            /// </summary>
            public interface IProtobuf
            {
                /// <summary>
                /// 序列化
                /// </summary>
                /// <typeparam name="T">需要序列化的协议类</typeparam>
                /// <param name="t_T">需要序列化的协议类的实例</param>
                /// <returns>序列化字节流</returns>
                byte[] Serialize<T>(T t_T);

                /// <summary>
                /// 反序列化
                /// </summary>
                /// <typeparam name="T">需要反序列化的协议类</typeparam>
                /// <param name="t_Byte">字节流</param>
                /// <returns>反序列化的对象实例</returns>
                T DeSerialize<T>(byte[] t_Byte);
            }

        }
    }
}


