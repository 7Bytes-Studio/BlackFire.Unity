/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using BlackFire.Unity.Network;

namespace BlackFire.Unity
{
    public sealed partial class NetworkManager
    {
        
        public TransportBase CreateUdpClient(string transportAlias,string uri)
        {
            CheckTransportExistsOrThrow(transportAlias);
            var udp = new UdpClient(uri);
            AddTransport(transportAlias,udp);
            return udp;
        }

        public TransportBase CreateUnityUdpClient(string transportAlias, string uri)
        {
            CheckTransportExistsOrThrow(transportAlias);
            var udp = new SyncUdpClient(uri);
            AddTransport(transportAlias, udp);
            StartCoroutine(udp);
            return udp;
        }
        
    }
}
