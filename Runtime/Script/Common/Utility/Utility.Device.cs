/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Collections.Generic;
using System.Net.NetworkInformation;

namespace BlackFire.Unity
{
    public static partial class Utility
    {

        public static class Device
        {
            /// <summary>
            /// 获取Mac地址列表。
            /// </summary>
            /// <returns>Mac地址列表。</returns>
            public static string[] AcquireMacList()
            {
                Boo.Lang.List<string> macList = new Boo.Lang.List<string>();
                NetworkInterface[] nis = NetworkInterface.GetAllNetworkInterfaces();
                foreach(NetworkInterface ni in nis)
                {
                    var mac = ni.GetPhysicalAddress().ToString();
                    if (!string.IsNullOrEmpty(mac))
                    {
                        macList.Add(mac.ToUpper());
                    }
                }
                return macList.ToArray();
            }


            /// <summary>
            /// 是否包含目标Mac地址。
            /// </summary>
            /// <param name="mac">目标Mac地址。</param>
            /// <returns>是否包含。</returns>
            public static bool HasMac(string mac)
            {
                var macList = AcquireMacList();
                return _HasMac(macList,mac);
            }


            private static bool _HasMac(string[] macList,string mac)
            {
                for (int i = 0; i < macList.Length; i++)
                {
                    if (mac.ToUpper()==macList[i])
                    {
                        return true;
                    }
                }
                return false;
            }


            /// <summary>
            /// 是否包含目标Mac地址。
            /// </summary>
            /// <param name="macs">目标Mac地址枚举。</param>
            /// <returns>是否包含。</returns>
            public static bool HasMac(IEnumerable<string> macs)
            {
                var macList = AcquireMacList();
                foreach (var item in macs)
                {
                    if (_HasMac(macList,item))
                    {
                        return true;
                    }
                }
                return false;
            }
            
            

        }
        
    }
}
