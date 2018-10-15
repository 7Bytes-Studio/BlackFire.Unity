/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using BlackFire.Unity.Network;
using UnityEngine;

namespace BlackFire.Unity
{
    /// <summary>
    /// 网络管家。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("BlackFire/Manager/Network")]
    public sealed partial class NetworkManager : ManagerBase,INetworkManager
    {
        private IDownloadModule m_DownloadModule = null;

        protected override void OnStart()
        {
            base.OnStart();
            InitModules();
        }


        private void InitModules()
        {
            RegisterModule<IDownloadModule>();
            m_DownloadModule = GetModule<IDownloadModule>();
        }
    }
}
