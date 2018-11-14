/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System.Collections;
using UnityEngine;

namespace BlackFire.Unity
{
    /// <summary>
    /// 摄像头协程类。
    /// </summary>
    public sealed class WebCam : CustomYieldInstruction
    {

        public int RequestedWidth { get; private set; }
        public int RequestedHeight { get; private set; }
        public int RequestedFPS { get; private set; }
        public WebCamTexture WebCamTexture { get; private set; }
        public WebCamDevice WebCamDevice { get; private set; }
        private bool m_KeepWaiting = true;
        private float m_TimeOut = 5f;
        private float m_TempTime = 0f;

        public WebCam(int requestedWidth, int requestedHeight, int requestedFPS=30)
        {
            RequestedWidth = requestedWidth;
            RequestedHeight = requestedHeight;
            RequestedFPS = requestedFPS;
            var waitAO = Application.RequestUserAuthorization(UserAuthorization.WebCam);
#if UNITY_2017_1_OR_NEWER
	        waitAO.completed += ao =>
            {
                WebCamDevice[] device = WebCamTexture.devices;
                if (null != device && 0 < device.Length)
                {
                    WebCamDevice = device[0];
                    var deviceName = device[0].name;
                    WebCamTexture = new WebCamTexture(deviceName, requestedWidth, requestedHeight, requestedFPS);
                    WebCamTexture.Play();
                }
                m_KeepWaiting = false;
            };
#elif UNITY_5
            var dmb = new GameObject("ForUnity5YieldBehavior.CustomYieldInstruction",typeof(ForUnity5YieldBehavior)).GetComponent<ForUnity5YieldBehavior>();
            dmb.StartCoroutine(WebCamYield(dmb,waitAO,requestedWidth,requestedHeight,requestedFPS));
#endif
        }

#if UNITY_5
        public sealed class ForUnity5YieldBehavior:MonoBehaviour{}
        private IEnumerator WebCamYield(ForUnity5YieldBehavior dmb,AsyncOperation waitAO,int requestedWidth, int requestedHeight, int requestedFPS=30)
        {
            yield return waitAO;
            WebCamDevice[] device = WebCamTexture.devices;
            if (null != device && 0 < device.Length)
            {
                WebCamDevice = device[0];
                var deviceName = device[0].name;
                WebCamTexture = new WebCamTexture(deviceName, requestedWidth, requestedHeight, requestedFPS);
                WebCamTexture.Play();
            }
            m_KeepWaiting = false;
            GameObject.DestroyImmediate(dmb.gameObject);
        }
#endif
        
       




        public override bool keepWaiting
        {
            get
            {
                return m_KeepWaiting && (m_TempTime += Time.deltaTime)<=m_TimeOut;
            }
        }
    }
}