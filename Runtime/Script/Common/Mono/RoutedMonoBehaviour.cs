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
	/// <summary>
	/// 可路由的MonoBehaviour。
	/// </summary>
	public class RoutedMonoBehaviour : MonoBehaviourEx
	{

		/// <summary>
		/// 路由事件处理函数。
		/// </summary>
		/// <param name="sender">发送者。</param>
		/// <param name="args">事件参数。</param>
		protected internal virtual void OnRoutedEvents(object sender,RoutedEventArgs args)
		{
			
		}

	}
}
