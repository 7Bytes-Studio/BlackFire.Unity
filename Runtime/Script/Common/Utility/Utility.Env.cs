/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/


using System;

namespace BlackFire.Unity
{
    public static partial class Utility
    {
        public static class Env
        {
            private static readonly string s_AppDirectory = null;
            public static string AppDirectory { get { return s_AppDirectory; } }

            private static object s_Lock = new object();

            static Env()
            {
                var fullPath = System.Diagnostics.Process.GetCurrentProcess().MainModule.FileName;
                var s = fullPath.Split('\\');
                var folder = string.Empty;
                for (int i = 0; i < s.Length - 1; i++)
                {
                    folder += s[i] + "\\";
                }
                s_AppDirectory = folder;
            }

           


            public static void SetCurrentDirectory(string directory)
            {
                lock (s_Lock)
                {
                    Environment.CurrentDirectory = directory;
                }
            }

            public static void ResetCurrentDirectory()
            {
                lock (s_Lock)
                {
                    Environment.CurrentDirectory = AppDirectory;
                }
            }

        }
    }
}
