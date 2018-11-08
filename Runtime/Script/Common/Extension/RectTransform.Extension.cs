//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using UnityEngine;

namespace BlackFire.Unity
{
    /// <summary>
    /// RectTransform辅助类
    /// </summary>
	public static class RectTransformExtension 
	{
        /// <summary>
        /// 设置高度
        /// </summary>
        /// <param name="rectTransform"></param>
        /// <param name="height"></param>
        public static void SetHeight(this RectTransform rectTransform,float height)
        {
            var rect = rectTransform.rect;
            rectTransform.sizeDelta = new Vector2(rect.width, height);
        }

        public static float Height(this RectTransform rectTransform)
        {
            return rectTransform.rect.height;
        }


        /// <summary>
        /// 设置宽度
        /// </summary>
        /// <param name="rectTransform"></param>
        /// <param name="width"></param>
        public static void SetWidth(this RectTransform rectTransform, float width)
        {
            var rect = rectTransform.rect;
            rectTransform.sizeDelta = new Vector2(width,rect.height);
        }

        public static float Width(this RectTransform rectTransform)
        {
            return rectTransform.rect.width;
        }


        public static void SetLeft(this RectTransform rectTransform, float left)
        {
            rectTransform.offsetMin = new Vector2(left, rectTransform.offsetMin.y);
        }

        public static void SetButtom(this RectTransform rectTransform,float buttom)
        {
            rectTransform.offsetMin = new Vector2(rectTransform.offsetMin.x,buttom);
        }

        public static void SetRight(this RectTransform rectTransform,float right)
        {
            rectTransform.offsetMax = new Vector2(-right, rectTransform.offsetMax.y);
        }

        public static void SetTop(this RectTransform rectTransform,float top)
        {
            rectTransform.offsetMax = new Vector2(rectTransform.offsetMax.y,-top);
        }


        public static float Left(this RectTransform rectTransform)
        {
            return rectTransform.offsetMin.x;
        }

        public static float Buttom(this RectTransform rectTransform)
        {
            return rectTransform.offsetMin.y;
        }

        public static float Right(this RectTransform rectTransform)
        {
           return -rectTransform.offsetMax.x;
        }

        public static float Top(this RectTransform rectTransform)
        {
            return -rectTransform.offsetMax.y;
        }
    }
}
