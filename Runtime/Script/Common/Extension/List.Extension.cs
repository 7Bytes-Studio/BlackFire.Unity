//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


using System;
using System.Collections.Generic;

namespace BlackFire.Unity
{
    /// <summary>
    /// List相关数据类型扩展
    /// </summary>
    public static class ListExtension
    {
        public static void SafeAdd<T>(this List<T> list, T value)
        {
            if (!list.Contains(value))
            {
                list.Add(value);
            }
        }
        
        
        public static void SafeAdd<T>(this List<T> list, T value,Predicate<T> predicate)
        {
            var target = list.Find(predicate);
            if (null==target)
            {
                list.Add(value);
            }
        }
        
        public static void SafeRemove<T>(this List<T> list, T value,Predicate<T> predicate)
        {
            var target = list.Find(predicate);
            if (null!=target)
            {
                list.Remove(value);
            }
        }
        
        
        public static void SafeRemove<T>(this List<T> list, T value)
        {
            if (list.Contains(value))
            {
                list.Remove(value);
            }
        }
        
        
    }
}
