/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using BlackFire.Unity.Network;
using System;
using UnityEngine;
using UnityEngine.Networking;

namespace BlackFire.Unity
{
    /// <summary>
    /// 使用HTTP协议的大文件下载器（支持断点续传）。
    /// </summary>
    public sealed class DownloadHttpBigFile : DownloadBase
    {
        public override event EventHandler OnDownloadSucceeded;
        public override event EventHandler<DownloadFailureEventArgs> OnDownloadFailure;
        public override event EventHandler<DownloadProgressEventArgs> OnDownloadProgress;

        private DownloadHandlerBigFile m_DownloadHandlerBigFile = null;
        private UnityWebRequest m_UnityWebRequest;
#if UNITY_2017_1_OR_NEWER
	        private UnityWebRequestAsyncOperation m_UnityWebRequestAsyncOperation = null;
#elif UNITY_5
            private AsyncOperation m_UnityWebRequestAsyncOperation = null;
#endif


        public override float DownloadProgress
        {
            get
            {
                return null== m_DownloadHandlerBigFile ? 0: m_DownloadHandlerBigFile.Progress;
            }
        }

        public override long DownloadRealSize
        {
            get
            {
                return null == m_DownloadHandlerBigFile ? 0 : m_DownloadHandlerBigFile.CurrentPosition;
            }
        }

        public override long DownloadContentSize
        {
            get
            {
                return null == m_DownloadHandlerBigFile ? 0 : m_DownloadHandlerBigFile.ContentLength;
            }
        }

        public override long DownloadPosition
        {
            get
            {
                return null == m_DownloadHandlerBigFile ? 0 : m_DownloadHandlerBigFile.Position;
            }
        }

        public override long DownloadRealContentSize
        {
            get
            {
                return null == m_DownloadHandlerBigFile ? 0 : m_DownloadHandlerBigFile.RealContentLength;
            }
        }

        public override bool IsDone
        {
            get
            {
                return null!=m_UnityWebRequestAsyncOperation ? m_UnityWebRequest.isDone:false;
            }
        }

        protected override void OnAct()
        {
            base.OnAct();


            //轮询检测错误通知。
#if UNITY_2017_1_OR_NEWER
	            if (!m_HasStop && null != m_UnityWebRequestAsyncOperation && !m_UnityWebRequestAsyncOperation.isDone && m_UnityWebRequestAsyncOperation.webRequest.isNetworkError)

#elif UNITY_5
            if (!m_HasStop && null != m_UnityWebRequestAsyncOperation && !m_UnityWebRequestAsyncOperation.isDone && m_UnityWebRequest.isError)

#endif
            {
                FireDownloadFailureEvent(DownloadErrorCode.ServerResponse, m_UnityWebRequest.error);
            }

            if (!m_HasStop && m_UnityWebRequestAsyncOperation.isDone) //轮询检测下载完毕事件。
            {
                if (null != OnDownloadSucceeded)
                {
                    OnDownloadSucceeded.Invoke(this, EventArgs.Empty);
                }
                Stop();
            }

            if (null != m_UnityWebRequestAsyncOperation && !m_UnityWebRequestAsyncOperation.isDone)//轮询通知下载进度。
            {
                if (null != OnDownloadProgress)
                {
                    OnDownloadProgress.Invoke(this, new DownloadProgressEventArgs(DownloadPosition, DownloadRealContentSize, DownloadRealSize, DownloadContentSize, DownloadProgress));
                }
            }

        }

        protected override void OnDie()
        {
            base.OnDie();
            Stop();
        }

        public override void Start(string url,string localPath,long contentSize)
        {
            if (!m_HasStop)
            {
                throw new Exception("Do not start again before closing.");
            }
            else
            {
                try
                {
                    m_DownloadHandlerBigFile = new DownloadHandlerBigFile(localPath,contentSize);
                }
                catch (Exception ex)
                {
                    FireDownloadFailureEvent(DownloadErrorCode.FileIOException, ex.Message);
                    throw ex;
                }

                //Log.Info("文件已经下载好了   "+m_DownloadHandlerBigFile.HasDownloadComplete);

                if (m_DownloadHandlerBigFile.HasDownloadComplete) //文件已经下载好了。
                {
                    if (null != OnDownloadProgress)
                    {
                        OnDownloadProgress.Invoke(this, new DownloadProgressEventArgs(DownloadPosition, DownloadRealContentSize, DownloadRealSize, DownloadContentSize, DownloadProgress));
                    }
                    if (null != OnDownloadSucceeded)
                    {
                        OnDownloadSucceeded.Invoke(this, EventArgs.Empty);
                    }
                    return;
                }

                m_UnityWebRequest = new UnityWebRequest(url);
                m_UnityWebRequest.method = UnityWebRequest.kHttpVerbGET;
                m_UnityWebRequest.downloadHandler = m_DownloadHandlerBigFile;
                m_UnityWebRequest.disposeDownloadHandlerOnDispose = true;
                m_UnityWebRequest.SetRequestHeader("range", "bytes=" + m_DownloadHandlerBigFile.Position + "-");
#if UNITY_2017_1_OR_NEWER
	                m_UnityWebRequestAsyncOperation = m_UnityWebRequest.SendWebRequest();
#elif UNITY_5
                m_UnityWebRequestAsyncOperation = m_UnityWebRequest.Send();
#endif
                

                m_HasStop = false;
            }


        }

        private bool m_HasStop=true;
        public override void Stop()
        {
            if (m_HasStop)
            {
                return;
            }
            else
            {
                m_DownloadHandlerBigFile.Close();
                m_DownloadHandlerBigFile = null;

#if UNITY_2017_1_OR_NEWER
	                if (!m_UnityWebRequestAsyncOperation.webRequest.isDone && !m_UnityWebRequestAsyncOperation.webRequest.isNetworkError)
#elif UNITY_5
                    if (!m_UnityWebRequest.isDone && !m_UnityWebRequest.isError)
#endif
                        FireDownloadFailureEvent(DownloadErrorCode.Stopped);

                m_UnityWebRequest.Dispose();
                m_UnityWebRequestAsyncOperation = null;

                m_HasStop = true;
            }
        }

        private void FireDownloadFailureEvent(DownloadErrorCode downloadErrorCode,string errorMessage=null)
        {
            if (null != OnDownloadFailure)
            {
                OnDownloadFailure.Invoke(this, new DownloadFailureEventArgs(downloadErrorCode, errorMessage));
            }
        }

    }
}
