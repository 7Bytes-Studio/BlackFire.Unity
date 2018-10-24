/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using Newtonsoft.Json;

namespace BlackFire.Unity
{
    public static partial class Utility
    {
    
        public static class Json
        {
            private static IJsonHelper s_JsonHelper;

            public static IJsonHelper JsonHelper {
                get { return s_JsonHelper ?? (s_JsonHelper=new DefaultJsonHelper()); }
                set { s_JsonHelper = value; }
            }

            public static string ToJson(object jsonObject)
            {
                return JsonHelper.ToJson(jsonObject);
            }
            
            public static object FromJson(string json,System.Type type)
            {
                return JsonHelper.FromJson(json,type);
            }
            
            public static T FromJson<T>(string json)
            {
                return (T)JsonHelper.FromJson(json,typeof(T));
            }
            
        }

    }

    public class DefaultJsonHelper : IJsonHelper
    {
        public string ToJson(object jsonObject)
        {
            return JsonConvert.SerializeObject(jsonObject);
        }

        public object FromJson(string json,Type type)
        {
            return JsonConvert.DeserializeObject(json,type);
        }
    }


    public interface IJsonHelper
    {
        string ToJson(object jsonObject);

        object FromJson(string json,Type type);
    }
    
}
