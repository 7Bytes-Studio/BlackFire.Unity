//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Unity;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;


namespace BlackFireFramework.Unity
{
    public sealed class DebuggerUIGUI : IDebuggerModuleGUI
    {
        public int Priority
        {
            get
            {
                return 6;
            }
        }

        public string ModuleName
        {
            get
            {
                return "UI";
            }
        }

        public void OnInit(DebuggerManager debuggerManager)
        {
           
        }

        private string m_CaptureEventData = null;
        private bool m_UseCapture;

        public void OnModuleGUI()
        {
            if (null==BlackFire.UI) return;
        }
        public void OnDestroy()
        {
           
        }
    }
}
