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
    public static class TransportEventArgsExtension 
	{
        public static string MessageString(this TransportEventArgs transportEventArgs,Encoding encoding)
        {
            return encoding.GetString(transportEventArgs.Message,0,transportEventArgs.Length);
        }

        public static string MessageString(this TransportEventArgs transportEventArgs)
        {
            return Encoding.UTF8.GetString(transportEventArgs.Message, 0, transportEventArgs.Length);
        }

    }
}
