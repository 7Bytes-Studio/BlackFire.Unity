/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using UnityEngine;
using BlackFire.Unity.Game;

namespace BlackFire.Unity
{
    /// <summary>
    /// 游戏管家。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("BlackFire/Manager/Game")]
	public sealed partial class GameManager : ManagerBase,IGameManager
    {

        /// <summary>
        /// 流程模块接口。
        /// </summary>
        private IProcessModule m_ProcessModule = null;


        protected override void OnStart()
        {
            base.OnStart();

            InitModule();

            InitSetting();

            InitProcess();

            InitState();
        }



        protected override void OnUpdate()
        {
            base.OnUpdate();
            
        }

        protected override void OnShutdown()
        {
            base.OnShutdown();
        }


        private void InitModule()
        {
            RegisterModule<IProcessModule>();
            m_ProcessModule = GetModule<IProcessModule>();
        }

    }
}
