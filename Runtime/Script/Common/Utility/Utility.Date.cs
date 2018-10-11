//----------------------------------------------------
//Copyright © 2008-2018 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------

using System;
using System.Net;

namespace BlackFire.Unity
{
    public static partial class Utility
    {
        public static class Date
        {
            /// <summary>  
            /// 获取网络日期时间  
            /// </summary>  
            /// <returns>网络时间字符串。</returns>  
            public static string AcquireNetDateTime()  
            {  
                WebRequest request = null;  
                WebResponse response = null;  
                WebHeaderCollection headerCollection = null;  
                string datetime = string.Empty;  
                try  
                {  
                    request = WebRequest.Create("https://www.baidu.com");  
                    request.Timeout = 3000;  
                    request.Credentials = CredentialCache.DefaultCredentials;  
                    response = (WebResponse)request.GetResponse();  
                    headerCollection = response.Headers;  
                    foreach (var h in headerCollection.AllKeys)  
                    { if (h == "Date") { datetime = headerCollection[h]; break; } }  
                    return datetime;  
                }  
                catch (Exception) { return datetime; }  
                finally  
                {  
                    if (request != null)  
                    { request.Abort(); }  
                    if (response != null)  
                    { response.Close(); }  
                    if (headerCollection != null)  
                    { headerCollection.Clear(); }  
                }  
            }
        }

    }
}
