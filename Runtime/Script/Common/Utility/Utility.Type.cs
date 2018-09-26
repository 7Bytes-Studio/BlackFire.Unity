﻿//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System.Collections;
using System.Collections.Generic;
using System.Reflection;

namespace BlackFireFramework.Unity
{
    public static partial class Utility
    {

        public static class Type
        {

            public static System.Type GetTypeInProject(string typeFullName)
            {
                var ac = Assembly.Load("Assembly-CSharp");
                var type = ac.GetType(typeFullName);
                if (null==type)
                {
                    var acfp = Assembly.Load("Assembly-CSharp-firstpass");
                    type = acfp.GetType(typeFullName);
                }
                return type;
            }

            
            public static System.Type[] GetTypesInProject(IEnumerable<string> typeFullNames)
            {
                var ac = Assembly.Load("Assembly-CSharp");
                var acfp = Assembly.Load("Assembly-CSharp-firstpass");
                var list = new List<System.Type>();
                foreach (var item in typeFullNames)
                {
                    var tp1 = ac.GetType(item);
                    if (null!=tp1)
                        list.Add(tp1);
                    
                    var tp2 = acfp.GetType(item);
                    if (null!=tp2)
                        list.Add(tp2);
                }
                return list.ToArray();
            }
            

        }

    }
}
