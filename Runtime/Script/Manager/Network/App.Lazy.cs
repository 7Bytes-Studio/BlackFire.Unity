//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFire.Unity;

public sealed partial class App
{
    private static INetworkManager s_Network = null;
    public static INetworkManager Network { get { return s_Network = (s_Network ?? GetManager<INetworkManager>()); } }
}