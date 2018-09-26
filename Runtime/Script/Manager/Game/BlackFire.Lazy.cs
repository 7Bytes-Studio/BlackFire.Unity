//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFire.Unity;

public sealed partial class App
{
    private static IGameManager s_Game = null;
    public static IGameManager Game { get { return s_Game = (s_Game ?? GetManager<IGameManager>()); } }

}