/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;

namespace BlackFire.Unity
{
    public sealed partial class App
    {
        [SerializeField] private string[] m_IoCRegisters;
        [SerializeField] private string[] m_AvailableIoCRegisters;

        private static ISparrowIoC s_IoC;

        public static ISparrowIoC IoC
        {
            get { return s_IoC ?? (s_IoC = Framework.CreateIoC()); }
        }

        private static void StartIoC()
        {
            var list = s_Instance.m_AvailableIoCRegisters;
            var tpList = new List<Type>();

            var acs = Assembly.Load("Assembly-CSharp");
            var acsfp = Assembly.Load("Assembly-CSharp-firstpass");
            for (int i = 0; i < list.Length; i++)
            {
                var tp1 = acs.GetType(list[i]);
                if (null != tp1)
                {
                    tpList.Add(tp1);
                }

                var tp2 = acsfp.GetType(list[i]);
                if (null != tp2)
                {
                    tpList.Add(tp2);
                }
            }


            for (int i = 0; i < tpList.Count; i++)
            {
                var ins = BlackFire.Utility.Reflection.New(tpList[i]) as IIoCRegister;
                ins.OnRegister(IoC);
            }
        }




    }

    /// <summary>
    /// IoC注册接口。
    /// </summary>
    public interface IIoCRegister
    {
        /// <summary>
        /// 注册事件。
        /// </summary>
        /// <param name="ioc">IoC实例。</param>
        void OnRegister(ISparrowIoC ioc);

    }
}