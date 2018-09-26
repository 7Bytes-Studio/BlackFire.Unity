//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;
using UnityEngine.UI;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// UGUI的Window类。
    /// </summary>
    public class UGUIWindow : UGUIForm , ILogic
    {
        public override ILogic Logic
        {
            get { return this; }
        }

  
    }
}