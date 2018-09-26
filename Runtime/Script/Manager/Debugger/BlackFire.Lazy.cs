//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFire.Unity;

public sealed partial class App
{
    private static IDebuggerManager s_Debugger = null;
    public static IDebuggerManager Debugger { get { return s_Debugger = (s_Debugger ?? GetManager<IDebuggerManager>()); } }
}