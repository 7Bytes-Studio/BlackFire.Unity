﻿//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using BlackFireFramework.Network;
using UnityEngine;

namespace BlackFireFramework.Unity
{
    /// <summary>
    /// 网络管家。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("BlackFire/Network")]
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