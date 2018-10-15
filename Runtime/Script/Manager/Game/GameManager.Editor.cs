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
	public sealed partial class GameManager
    {
#if UNITY_EDITOR

        [SerializeField] private bool m_ProcessScrowFoldOut;

        private void Reset()
        {
            m_AvailableProcesses = null;
        }

#endif
    }
}
