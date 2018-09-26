//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using UnityEngine;

namespace BlackFire.Unity
{

    /// <summary>
    /// UI管家。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("BlackFire/UI")]
    public sealed partial class UIManager : ManagerBase,IUIManager
	{
        [SerializeField] private string m_IUIEventDataHelperTypeFullName = string.Empty;

		protected override void OnStart()
        {
            base.OnStart();
        }

	}
}
