//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

namespace BlackFire.Unity.Editor
{
	public static class AnimImageHierarchy
	{
		
		[MenuItem("GameObject/UI/Anim Image")]
		private static void OnMenuItemClick_ScriptableObjectCreator()
		{
			if (null!=Selection.activeGameObject)
			{
				CreateAnimImage(Selection.activeGameObject.transform);
			}
			else
			{
				var canvas = Object.FindObjectOfType<Canvas>();
				if (null!=canvas)
				{
					CreateAnimImage(canvas.transform);
				}
				else
				{
					var canvasIns = new GameObject("Canvas");
					var canvasCmp = canvasIns.AddComponent<Canvas>();
					canvasCmp.renderMode = RenderMode.ScreenSpaceOverlay;
					var canvasScalerCmp = canvasIns.AddComponent<CanvasScaler>();
					CreateAnimImage(canvasIns.transform);
				}
			}
		}


		private static void CreateAnimImage(Transform pTf)
		{
		    var animImage = new GameObject("Anim Image",typeof(AnimImage));
			animImage.transform.SetParent(pTf);
			animImage.GetComponent<RectTransform>().anchoredPosition = Vector2.zero;
		}

	}
}