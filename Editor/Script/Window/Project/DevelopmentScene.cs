/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

// ScriptMainLogicWriter : https://github.com/Yawpp

using System.Collections.Generic;
using UnityEngine;

namespace BlackFire.Unity.Editor
{

	public sealed class DevelopmentScene : ScriptableObject
	{				
		[SerializeField] private List<Object> m_Scenes = new List<Object>();

		public List<Object> Scenes
		{
			get { return m_Scenes; }
		}
	}
	
}