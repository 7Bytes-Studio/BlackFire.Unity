/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Text;
using CatEngine.SpaceSystem;
using UnityEngine;

namespace BlackFire.Unity
{
    public static partial class Utility
    {
        public static class Clipboard
        {

            public static string ClipboardBuffer
            {
                get { return GUIUtility.systemCopyBuffer; }
                set { GUIUtility.systemCopyBuffer = value; }
            }


            public static void SetCommandToClipboard(string key,string body)
            {
                ClipboardBuffer = string.Format("{0} {1}",key.Trim(),body.Trim());
            }
           
            public static string GetCommandFromClipboard()
            {
                return ClipboardBuffer;
            }
            
            
            public static string GetCommandBodyFromClipboard(string key)
            {
                var s = ClipboardBuffer.Split(' ');
                
                if (null!=s&&s[0]==key)
                {
                    var r = ClipboardBuffer.Slice(string.Format("{0}:",s[0].Length));
                    return r.Trim();
                }
                return string.Empty;
            }


            public static void ToJsonCommand(string key,object body)
            {
                SetCommandToClipboard(key,Json.ToJson(body)); 
            }


            public static T FromJsonCommand<T>(string key)
            {
                var bodyJson = GetCommandBodyFromClipboard(key);
                return Json.FromJson<T>(bodyJson);
            }

        }

    }
}
