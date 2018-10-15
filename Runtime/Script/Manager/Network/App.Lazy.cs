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
    public sealed partial class App
    {
        private static INetworkManager s_Network = null;

        public static INetworkManager Network
        {
            get { return s_Network = (s_Network ?? GetManager<INetworkManager>()); }
        }
    }
}