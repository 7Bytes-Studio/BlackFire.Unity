/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using UnityEngine;

namespace BlackFire.Unity
{

    public sealed partial class App
    {
        /// <summary>
        /// 应用程序退出事件。
        /// </summary>
        public static event Action ApplicationQuit;

        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.BeforeSceneLoad)]
        private static void ApplicationInit()
        {
            StreamingAssetsPath = Application.streamingAssetsPath;
        }


        public static string StreamingAssetsPath { get; private set; }


        private void OnApplicationQuit()
        {
            if (null != ApplicationQuit)
            {
                ApplicationQuit.Invoke();
            }
        }

    }
}