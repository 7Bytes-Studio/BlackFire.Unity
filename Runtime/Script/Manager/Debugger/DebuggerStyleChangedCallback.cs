/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using UnityEngine;

namespace BlackFire.Unity
{
    public sealed class DebuggerStyleChangedCallback : IDebuggerStyleChangeCallback
    {
        public int Priority
        {
            get
            {
                return 66666;
            }
        }

        public bool HiddenStylePredicate(DebuggerManager debuggerManager)
        {
            return Input.GetKeyDown(KeyCode.F1);
        }

        public bool MiniStylePredicate(DebuggerManager debuggerManager)
        {
            return Input.GetKeyDown(KeyCode.F2);
        }

        public bool FullStylePredicate(DebuggerManager debuggerManager)
        {
            return Input.GetKeyDown(KeyCode.F3);
        }

    }
}
