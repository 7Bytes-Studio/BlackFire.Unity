/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using UnityEngine;

namespace BlackFire.Unity
{

    /// <summary>
    /// UI管家。
    /// </summary>
    [DisallowMultipleComponent]
    [AddComponentMenu("BlackFire/Manager/UI")]
    public sealed partial class UIManager : ManagerBase,IUIManager
	{
        [SerializeField] private string m_IUIEventDataHelperTypeFullName = string.Empty;

		private IUIEventModule m_UIEventModule = new UIEventModule();
		
		public IUIEventDataHelper UIEventDataHelper
		{
			get { return m_UIEventModule.UIEventDataHelper; }
		}
		
		protected override void OnStart()
        {
            base.OnStart();
	        m_UIEventModule.UIEventDataHelper = (IUIEventDataHelper)gameObject.AddComponent( Type.GetType(m_IUIEventDataHelperTypeFullName) );
        }


	}
}
