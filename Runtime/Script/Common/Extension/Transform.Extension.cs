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
	/// Transform扩展类。
	/// </summary>
    public static class TransformExtension
	{

		/// <summary>
		/// 遍历策略。
		/// </summary>
		public enum TraverseStrategy
		{
			/// <summary>
			/// 广度遍历。
			/// </summary>
			Breadth,
			/// <summary>
			/// 深度遍历。
			/// </summary>
			Depth
		}
		
	
		#region Traverse

		/// <summary>
		/// 遍历Transform树。
		/// </summary>
		/// <param name="node">可Transform节点。</param>
		/// <param name="callback">遍历回调。</param>
		/// <param name="traverseStrategy">遍历策略。</param>
		public static void Traverse(this Transform node,Predicate<Transform> callback,TraverseStrategy traverseStrategy = TraverseStrategy.Breadth)
		{
			if(null==callback || null==node) return;

			callback.Invoke(node);
			switch (traverseStrategy)
			{
				case TraverseStrategy.Breadth : Breadth(node,callback);
					break;
				case TraverseStrategy.Depth : Depth(node,callback);
					break;
				default: return;
			}   
		}
        
		private static void Breadth(Transform node,Predicate<Transform> callback)
		{
			foreach (Transform child in node)
			{
				if(callback.Invoke(child))
					return;
			}
			foreach (Transform child in node)
			{
				Breadth(child,callback);
			}
		}
        
		private static void Depth(Transform node,Predicate<Transform> callback)
		{
			foreach (Transform child in node)
			{
				Depth(child,callback);
				if(callback.Invoke(child))
					return;
			}
		}

		#endregion
		
		
		#region ReverseTraverse

		/// <summary>
		/// 反向遍历Transform树。
		/// </summary>
		/// <param name="node">Transform节点。</param>
		/// <param name="callback">反向遍历回调。</param>
		public static void ReverseTraverse(this Transform node,Predicate<Transform> callback)
		{
			if(null==callback || null==node) return;
            
			var current = node;
			while (null!=current)
			{
				if (callback.Invoke(current))
					return;
				current = current.parent;
			}
		}

		#endregion
		
		
			
		#region Traverse

		/// <summary>
		/// 遍历Transform树。
		/// </summary>
		/// <param name="node">可Transform节点。</param>
		/// <param name="callback">遍历回调。</param>
		/// <param name="traverseStrategy">遍历策略。</param>
		public static void Traverse(this Transform node,Action<Transform> callback,TraverseStrategy traverseStrategy = TraverseStrategy.Breadth)
		{
			if(null==callback || null==node) return;

			callback.Invoke(node);
			switch (traverseStrategy)
			{
				case TraverseStrategy.Breadth : Breadth(node,callback);
					break;
				case TraverseStrategy.Depth : Depth(node,callback);
					break;
				default: return;
			}   
		}
        
		private static void Breadth(Transform node,Action<Transform> callback)
		{
			foreach (Transform child in node)
			{
				callback.Invoke(child);
			}
			foreach (Transform child in node)
			{
				Breadth(child,callback);
			}
		}
        
		private static void Depth(Transform node,Action<Transform> callback)
		{
			foreach (Transform child in node)
			{
				Depth(child,callback);
				callback.Invoke(child);
			}
		}

		#endregion
		
		
		#region ReverseTraverse

		/// <summary>
		/// 反向遍历Transform树。
		/// </summary>
		/// <param name="node">Transform节点。</param>
		/// <param name="callback">反向遍历回调。</param>
		public static void ReverseTraverse(this Transform node,Action<Transform> callback)
		{
			if(null==callback || null==node) return;
            
			var current = node;
			while (null!=current)
			{
				callback.Invoke(current);
				current = current.parent;
			}
		}

		#endregion
		
		
	}
}
