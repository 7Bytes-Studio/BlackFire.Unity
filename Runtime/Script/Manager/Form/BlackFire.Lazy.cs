﻿//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;

public sealed partial class BlackFire
{
    private static IFormManager s_Form = null;
    public static IFormManager Form { get { return s_Form = (s_Form ?? GetManager<IFormManager>()); } }
}