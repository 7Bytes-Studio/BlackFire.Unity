/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using System.Collections;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

namespace BlackFire.Unity
{
    public static partial class Utility
    {
        public static class Date
        {
#if UNITY_5
            public sealed class ForUnity5YieldBehavior:MonoBehaviour{}
#endif

            public static string NetDateAPI = @"https://www.baidu.com";
            
            /// <summary>  
            /// 获取网络日期时间。 
            /// </summary>  
            public static void AcquireNetDateTime(Action<string> netDateCallback,Action networkErrorCallback=null)  
            {  
                
                UnityWebRequest uwr = new UnityWebRequest(NetDateAPI);
#if UNITY_2017_1_OR_NEWER
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
#elif UNITY_5

                var dmb = new GameObject("ForUnity5YieldBehavior.Utility.Date",typeof(ForUnity5YieldBehavior)).GetComponent<ForUnity5YieldBehavior>();
                dmb.StartCoroutine(AcquireNetDateTimeYiled(dmb,uwr,netDateCallback,networkErrorCallback));
#endif

            }
            
#if UNITY_5
            private static IEnumerator AcquireNetDateTimeYiled(ForUnity5YieldBehavior dmb,UnityWebRequest uwr,Action<string> netDateCallback,Action networkErrorCallback=null)
            {
                var ao = uwr.Send();
                yield return ao;
                if (null != netDateCallback)
                {
                    if (!uwr.isError)
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
                        if (null != networkErrorCallback)
                        {
                            networkErrorCallback.Invoke();
                        }
                    }
                }
                GameObject.DestroyImmediate(dmb.gameObject);
            }
#endif
            
            
            
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
