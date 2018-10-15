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
        public TransportBase CreateWebSocketClient(string transportAlias, string uri, Encoding encoding)
        {
            CheckTransportExistsOrThrow(transportAlias);
            var ws = new WebSocketClient(uri,encoding);
            AddTransport(transportAlias, ws);
            return ws;
        }

        public TransportBase CreateWebSocketClient(string transportAlias, string uri)
        {
            CheckTransportExistsOrThrow(transportAlias);
            var ws = new WebSocketClient(uri,Encoding.UTF8);
            AddTransport(transportAlias, ws);
            return ws;
        }


        public TransportBase CreateUnityWebSocketClient(string transportAlias,string uri,Encoding encoding)
        {
            CheckTransportExistsOrThrow(transportAlias);
            var ws = new SyncWebSocketClient(uri,encoding);
            AddTransport(transportAlias,ws);
            StartCoroutine(ws);
            return ws;
        }


        public TransportBase CreateUnityWebSocketClient(string transportAlias,string uri)
        {
            CheckTransportExistsOrThrow(transportAlias);
            var ws = new SyncWebSocketClient(uri,Encoding.UTF8);
            AddTransport(transportAlias, ws);
            StartCoroutine(ws);
            return ws;
        }

    }
}
