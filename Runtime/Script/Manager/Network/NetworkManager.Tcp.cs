/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Text;
using UnityEngine;
using BlackFire.Unity.Network;

namespace BlackFire.Unity
{
    public sealed partial class NetworkManager
    {
        public TransportBase CreateTcpClient(string transportAlias,string uri)
        {
            CheckTransportExistsOrThrow(transportAlias);
            var tcp = new TcpClient(uri);
            AddTransport(transportAlias,tcp);
            return tcp;
        }

        public TransportBase CreateUnityTcpClient(string transportAlias, string uri)
        {
            CheckTransportExistsOrThrow(transportAlias);
            var tcp = new SyncTcpClient(uri);
            AddTransport(transportAlias, tcp);
            StartCoroutine(tcp);
            return tcp;
        }
    }
}
