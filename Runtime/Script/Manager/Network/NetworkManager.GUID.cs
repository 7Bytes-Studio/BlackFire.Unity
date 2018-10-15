/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Diagnostics;
using System.Net.NetworkInformation;
using UnityEngine;

namespace BlackFire.Unity
{
    public sealed partial class NetworkManager
    {
        private string m_GUID=null;
        public string GUID
        {
            get { return m_GUID??(m_GUID=SystemInfo.deviceUniqueIdentifier+Process.GetCurrentProcess().Id);}
        }
    }
}
