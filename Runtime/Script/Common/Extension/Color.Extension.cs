//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


using System;
using System.Collections.Generic;
using UnityEngine;

namespace BlackFire.Unity
{
    /// <summary>
    /// List相关数据类型扩展
    /// </summary>
    public static class ColorExtension
    {
        /// <summary>
        /// 十六进制颜色表示。
        /// </summary>
        /// <param name="colorSr">十六进制颜色表示字符串。</param>
        /// <returns>颜色。</returns>
        public static Color Hexadecimal(this string colorSr)
        {
            if (colorSr.Contains("#"))
            {
                colorSr = colorSr.Replace("#",string.Empty).Trim();
            }
            
            if (2>=colorSr.Length)
            {
                var rs = colorSr.Slice("0:2");
                var r = Convert.ToInt32(rs, 16);
                return new Color(r / 255f, 0f, 0f, 1f);
            }
            else if(4>=colorSr.Length) 
            {
                var rs = colorSr.Slice("0:2");
                var r = Convert.ToInt32(rs, 16);
                
                var gs = colorSr.Slice("2:4");
                var g = Convert.ToInt32(gs, 16);
                
                return  new Color(r / 255f, g / 255f, 0f, 1f);
            }
            else if(6>=colorSr.Length) 
            {
                var rs = colorSr.Slice("0:2");
                var r = Convert.ToInt32(rs, 16);
                
                var gs = colorSr.Slice("2:4");
                var g = Convert.ToInt32(gs, 16);
                
                var bs = colorSr.Slice("4:6");
                var b = Convert.ToInt32(bs, 16);
                
                return new Color(r / 255f, g / 255f, b / 255f, 1f);
            }
            else if(8>=colorSr.Length) 
            {
                var rs = colorSr.Slice("0:2");
                var r = Convert.ToInt32(rs, 16);
                
                var gs = colorSr.Slice("2:4");
                var g = Convert.ToInt32(gs, 16);
                
                var bs = colorSr.Slice("4:6");
                var b = Convert.ToInt32(bs, 16);
                
                var @as = colorSr.Slice("6:8");
                var a = Convert.ToInt32(@as, 16);
                
                new Color(r / 255f, g / 255f, b / 255f, a / 255f);
            }

            return Color.clear;
        }

        public static Color SetR(this Color color,float value)
        {
            return new Color(value,color.g,color.b,color.a);
        }

        public static Color SetG(this Color color,float value)
        {
            return new Color(color.r,value,color.b,color.a);
        }

        public static Color SetB(this Color color,float value)
        {
            return new Color(color.r,color.g,value,color.a);
        }

        public static Color SetA(this Color color,float value)
        {
            return new Color(color.r,color.g,color.b,value);
        }
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
        
    }
}
