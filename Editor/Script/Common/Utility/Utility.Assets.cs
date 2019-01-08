/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

namespace BlackFire.Unity.Editor
{
    public static partial class Utility
    {
        public static class Assets
        {

            public static IEnumerable<T> FindScriptableObject<T>() where T:ScriptableObject
            {
               var results = AssetDatabase.FindAssets("t:"+typeof(T).FullName);
               var list = new List<T>();
               foreach (var result in results)
               {
                   var ins = AssetDatabase.LoadAssetAtPath<T>(AssetDatabase.GUIDToAssetPath(result));
                   list.Add(ins);
               }
               return list;
            }

        }
    }
}
