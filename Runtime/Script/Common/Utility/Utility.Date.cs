//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Net;
using UnityEngine.Networking;

namespace BlackFire.Unity
{
    public static partial class Utility
    {
        public static class Date
        {

            public static string NetDateAPI = @"https://www.baidu.com";
            
            /// <summary>  
            /// 获取网络日期时间。 
            /// </summary>  
            public static void AcquireNetDateTime(Action<string> netDateCallback,Action networkErrorCallback=null)  
            {  
                
                UnityWebRequest uwr = new UnityWebRequest(NetDateAPI);
                var ao = uwr.SendWebRequest();
                ao.completed += a =>
                {
                    if (null!=netDateCallback)
                    {
                        if (!uwr.isNetworkError && !uwr.isHttpError)
                        {
                            var headerDic = uwr.GetResponseHeaders();
                            foreach (var kv in headerDic)  
                            { 
                                //Log.Info(kv.Key);
                                if (kv.Key == "Date")
                                {
                                    netDateCallback.Invoke(kv.Value);
                                    break;
                                }
                            } 
                        }
                        else
                        {
                            if (null!=networkErrorCallback)
                            {
                                networkErrorCallback.Invoke();
                            }
                        }
                    }
                };
                
            }
            
            /// <summary>
            /// GMT转化为本地日期。
            /// </summary>
            /// ex "Thu, 29 Sep 2014 07:04:39 GMT"
            public static DateTime GMT2Local(string gmt)
            {
                DateTime dt = DateTime.MinValue;
                try
                {
                    string pattern = "";
                    if (gmt.IndexOf("+0") != -1)
                    {
                        gmt = gmt.Replace("GMT", "");
                        pattern = "ddd, dd MMM yyyy HH':'mm':'ss zzz";
                    }
                    if (gmt.ToUpper().IndexOf("GMT") != -1)
                    {
                        pattern = "ddd, dd MMM yyyy HH':'mm':'ss 'GMT'";
                    }
                    if (pattern != "")
                    {
                        dt = DateTime.ParseExact(gmt, pattern, System.Globalization.CultureInfo.InvariantCulture, System.Globalization.DateTimeStyles.AdjustToUniversal);
                        dt = dt.ToLocalTime();
                    }
                    else
                    {
                        dt = Convert.ToDateTime(gmt);
                    }
                }
                catch
                {
                }
                return dt;
            }
        }

    }
}
