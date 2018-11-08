//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


using UnityEngine;

namespace BlackFire.Unity
{
    /// <summary>
    /// 材质类型扩展
    /// </summary>
    public static class MaterialExtension
    {
        public static void SetColorR(this Material material,float value)
        {
            value = Mathf.Clamp01(value);
            var color = material.color;
            material.color = new Color(value, color.g, color.b, color.a);
        }

        public static void SetColorG(this Material material, float value)
        {
            value = Mathf.Clamp01(value);
            var color = material.color;
            material.color = new Color(color.r, value , color.b, color.a);
        }

        public static void SetColorB(this Material material, float value)
        {
            value = Mathf.Clamp01(value);
            var color = material.color;
            material.color = new Color(color.r, color.g, value, color.a);
        }

        public static void SetColorA(this Material material, float value)
        {
            value = Mathf.Clamp01(value);
            var color = material.color;
            material.color = new Color(color.r, color.g, color.b, value);
        }

    }
}
