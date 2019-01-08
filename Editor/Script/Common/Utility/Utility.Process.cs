/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/


using System;
using System.Diagnostics;
using System.Text;

namespace BlackFire.Unity.Editor
{
    public static partial class Utility
    {
        public static class Process
        {
            public static void Start(string fileName,string args=null,Encoding standardOutputEncoding = null,Action<string> output=null,Action exit=null, bool waitForExit = false)
            {
                using (var process = new System.Diagnostics.Process())
                {
                    process.StartInfo = new ProcessStartInfo();
                    process.StartInfo.FileName = fileName;
                    process.StartInfo.Arguments = args;
                    process.StartInfo.CreateNoWindow = true;
                    process.StartInfo.UseShellExecute = false;
                    process.StartInfo.RedirectStandardOutput = true;
                    process.StartInfo.StandardOutputEncoding = null==standardOutputEncoding?Encoding.Default:standardOutputEncoding;
                    process.OutputDataReceived += (sender, eventArgs) =>
                    {

                        if (null!=output)
                        {
                            output.Invoke(eventArgs.Data);
                        }
                        else
                        {
                        }
                    };
                    process.Start();
                    process.BeginOutputReadLine();
                    if (waitForExit)
                    {
                        process.WaitForExit();
                    }
                    if (process.HasExited)
                    {
                        if (null!=exit)
                        {
                            exit.Invoke();
                        }
                    }
                }
            }

            public static void Cmd(string args)
            {
                System.Diagnostics.Process p = new System.Diagnostics.Process();
                p.StartInfo.FileName = "cmd.exe";
                p.StartInfo.UseShellExecute = false;
                p.StartInfo.RedirectStandardInput = true;
                p.StartInfo.RedirectStandardOutput = true;
                p.StartInfo.CreateNoWindow = true;
                p.Start();
                p.StandardInput.WriteLine(args);
                p.StandardInput.WriteLine("exit"); //需要有这句，不然程序会挂机
            }

        }

    }
}