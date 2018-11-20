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
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using UnityEngine;
using UnityEngine.Networking;

namespace BlackFire.Unity
{
    public static partial class Utility
    {
        /// <summary>
        /// 更新类。
        /// </summary>
        public static class UpDownload
        {
            
#region 上传
            
            /// <summary>
            /// 上传文件(服务器直传)
            /// </summary>
            /// <param name="url">上传地址</param>
            /// <param name="data">文件二进制数据</param>
            /// <param name="name">文件的全名(包括扩展名)</param>
            /// <param name="field">上传表单的字段名</param>
            /// <param name="mime">上传表单的MIME类型</param>
            /// <param name="callback">服务器响应回调</param>
            public static IEnumerator UpLoad(string url,byte[] data, string name, string field, string mime,Action<string> callback=null)
            {
                return UpLoadYield(url,data, name, field, mime,callback);
            }
    
            private static IEnumerator UpLoadYield(string url,byte[] data, string name, string field, string mime, Action<string> callback)
            {
                WWWForm form = new WWWForm();
                form.AddBinaryData(field, data, name, mime);
                using (UnityWebRequest www = UnityWebRequest.Post(url, form))
                {
#if UNITY_2017_1_OR_NEWER
	                    yield return www.SendWebRequest();
#elif UNITY_5
                    yield return www.Send();
#endif
                    if (www.isDone)
                    {
                        if (null != callback)
                        {
                            callback.Invoke(www.downloadHandler.text);
                        }
                    }
#if UNITY_2017_1_OR_NEWER
	                    else if(www.isNetworkError)

#elif UNITY_5
                    else if(www.isError)
#endif
                    {
                        if (null != callback)
                        {
                            callback.Invoke(www.error);
                        }
                    }
                }
            }
    
            /// <summary>
            /// 上传文件(懒人上传模式)
            /// </summary>
            /// <param name="url">上传文件地址</param>
            /// <param name="field">上传表单的字段名</param>
            /// <param name="dirPath">上传文件的文件夹路径名</param>
            /// <param name="fileName">上传的文件全名(包括后缀名)</param>
            public static void UpLoadLazy(string url,string field,string dirPath,string fileName,Action<string> callback= null)
            {
                using (var fs = new FileStream(Application.streamingAssetsPath + "/"+fileName, FileMode.Open, FileAccess.Read))
                {
                    using (BinaryReader br = new BinaryReader(fs))
                    {
                        var data = br.ReadBytes((int)fs.Length);
                        var split = fileName.Split('.');             
                        UpLoad(url, data,fileName,field,split[split.Length-1],callback);
                    }
                }
            }
            
#endregion
            
#region 下载        

            /// <summary>
            /// 下载速度。
            /// </summary>
            public static int DownloadSpeed = 100 * 1024 * 1024; //100M 带宽

            /// <summary>
            /// 临时文件扩展名。
            /// </summary>
            public static string DownloadTempFile = ".tmp";

            private static readonly Dictionary<string, HttpDownloader> s_DownloadTasks = new Dictionary<string, HttpDownloader>();

            /// <summary>
            /// 下载任务的名字集合。
            /// </summary>
            public static IEnumerable<string> TaskNames
            {
                get
                {
                    lock (s_DownloadTasks)
                    {
                        return s_DownloadTasks.Keys;
                    }
                }
            }

            /// <summary>
            /// 是否存在下载任务。
            /// </summary>
            /// <param name="taskName">任务名字。</param>
            /// <returns>是否存在。</returns>
            public static bool HasDownloadTask(string taskName)
            {
                lock (s_DownloadTasks)
                {
                    return s_DownloadTasks.ContainsKey(taskName);
                }
            }

            private static HttpDownloader GetDownloadTask(string taskName)
            {
                lock (s_DownloadTasks)
                {
                    return s_DownloadTasks.ContainsKey(taskName) ? s_DownloadTasks[taskName] : null;
                }
            }

            private static void SetDownloadTask(string key, HttpDownloader value)
            {
                lock (s_DownloadTasks)
                {
                    if (!s_DownloadTasks.ContainsKey(key))
                    {
                        s_DownloadTasks.Add(key, value);
                    }
                }
            }

            /// <summary>
            /// 建立下载任务。
            /// </summary>
            /// <param name="downloadTaskInfo">下载信息。</param>
            public static void NewDownloadTask(DownloadTaskInfo downloadTaskInfo)
            {
                var dowloader = new HttpDownloader(new HttpDownloadInfo()
                {
                    Url = downloadTaskInfo.Url,
                    SavePath = downloadTaskInfo.Path,
                    TempFileExtension = DownloadTempFile,
                    DownloadBufferUnit = DownloadSpeed
                });
                dowloader.OnDownloadSuccess += (sender, args) =>
                {
                    if (null != downloadTaskInfo.SuccessCallback) downloadTaskInfo.SuccessCallback.Invoke();
                };
                dowloader.OnDownloadProgress += (sender, args) =>
                {
                    if (null != downloadTaskInfo.ProgressCallback) downloadTaskInfo.ProgressCallback.Invoke(args.DownloadProgress);
                };
                dowloader.OnDownloadFailure += (sender, args) =>
                {
                    if (null != downloadTaskInfo.failureCallback) downloadTaskInfo.failureCallback.Invoke();
                };
                SetDownloadTask(downloadTaskInfo.TaskName, dowloader);
                dowloader.StartDownload();

            }

            /// <summary>
            /// 建立异步下载任务。
            /// </summary>
            /// <param name="downloadTaskInfo">下载信息。</param>
            public static void NewDownloadTaskAsync(DownloadTaskInfo downloadTaskInfo)
            {

                Job.StartLongNew(state => {
                    var dowloader = new HttpDownloader(new HttpDownloadInfo()
                    {
                        Url = downloadTaskInfo.Url,
                        SavePath = downloadTaskInfo.Path,
                        TempFileExtension = DownloadTempFile,
                        DownloadBufferUnit = DownloadSpeed
                    });
                    dowloader.OnDownloadSuccess += (sender, args) =>
                    {
                        if (null != downloadTaskInfo.SuccessCallback) downloadTaskInfo.SuccessCallback.Invoke();
                    };
                    dowloader.OnDownloadProgress += (sender, args) =>
                    {
                        if (null != downloadTaskInfo.ProgressCallback) downloadTaskInfo.ProgressCallback.Invoke(args.DownloadProgress);
                    };
                    dowloader.OnDownloadFailure += (sender, args) =>
                    {
                        if (null != downloadTaskInfo.failureCallback) downloadTaskInfo.failureCallback.Invoke();
                    };
                    SetDownloadTask(downloadTaskInfo.TaskName, dowloader);
                    dowloader.StartDownload(true);

                });

            }

            /// <summary>
            /// 取消下载任务。
            /// </summary>
            /// <param name="taskName">任务名字。</param>
            public static void CancelDownloadTask(string taskName)
            {
                var downloader = GetDownloadTask(taskName);
                downloader.StopDownload();
            }

            /// <summary>
            /// 建立异步多下载任务。
            /// </summary>
            /// <param name="multiDownloadTaskInfo">下载信息。</param>
            public static void NewMultiDownloadTask(IEnumerable<MultiDownloadTaskInfo> multiDownloadTaskInfo, Action<float> totalProgressCb = null, Action<string, int> countCb = null, Action finishCb = null)
            {
                var t = new Dictionary<string, float>();
                var total = multiDownloadTaskInfo.Count();
                var o = new object();
                var index = 0;
                foreach (var task in multiDownloadTaskInfo)
                {
                    lock (t)
                    {
                        t.Add(task.TaskName, 0f);
                    }

                    NewDownloadTaskAsync(new DownloadTaskInfo()
                    {
                        Url = task.Url,
                        TaskName = task.TaskName,
                        Path = task.Path,
                        SuccessCallback = () =>
                        {
                            if (null != task.SuccessCallback) task.SuccessCallback.Invoke(task.TaskName);
                            lock (o)
                            {
                                ++index;
                                if (null != countCb)
                                {
                                    countCb.Invoke(task.TaskName, index);
                                }
                            }
                        },
                        ProgressCallback = p =>
                        {
                            if (null != task.ProgressCallback) task.ProgressCallback.Invoke(task.TaskName, p);
                            lock (t)
                            {
                                t[task.TaskName] = p;
                                var tp = 0f;
                                foreach (var v in t.Values)
                                {
                                    tp += v;
                                }

                                var progress = tp / total;
                                if (null != totalProgressCb)
                                {
                                    totalProgressCb.Invoke(progress);
                                }

                                if (null != finishCb && 1 == progress)
                                {
                                    finishCb.Invoke();
                                }
                            }
                        },
                        failureCallback = () => { if (null != task.failureCallback) task.failureCallback.Invoke(task.TaskName); }
                    });

                }
            }

            /// <summary>
            /// 建立异步多下载任务队列。
            /// </summary>
            /// <param name="multiDownloadTaskInfo">下载信息。</param>
            /// <param name="countCb">执行回调。</param>
            public static void NewMultiDownloadTaskQueue(IEnumerable<MultiDownloadTaskInfo> multiDownloadTaskInfo, Action<float> totalProgressCb = null, Action<string, int> countCb = null, Action finishCb = null)
            {
                var total = multiDownloadTaskInfo.Count();
                var index = 0;
                Job.StartLongNew(state =>
                {
                    foreach (var task in multiDownloadTaskInfo)
                    {
                        NewDownloadTask(new DownloadTaskInfo()
                        {
                            Url = task.Url,
                            TaskName = task.TaskName,
                            Path = task.Path,
                            SuccessCallback = () => { if (null != task.SuccessCallback) task.SuccessCallback.Invoke(task.TaskName); },
                            ProgressCallback = p => {
                                if (null != task.ProgressCallback) task.ProgressCallback.Invoke(task.TaskName, p);
                                var progress = (index + p) / total;
                                if (null != totalProgressCb) totalProgressCb.Invoke(progress);
                                
                            },
                            failureCallback = () => { if (null != task.failureCallback) task.failureCallback.Invoke(task.TaskName); }
                        });

                        ++index;
                        if (null != countCb)
                        {
                            countCb.Invoke(task.TaskName, index);
                        }
                    }

                    if (null != finishCb)
                    {
                        finishCb.Invoke();
                    }

                });
            }
            
            
#endregion

#region 内嵌类

    /// <summary>
    /// 下载任务的信息类。
    /// </summary>
    public struct DownloadTaskInfo
    {
        /// <summary>
        /// 任务名字。
        /// </summary>
        public string TaskName;
        /// <summary>
        /// 统一资源定位符。
        /// </summary>
        public string Url;
        /// <summary>
        /// 保存路径。
        /// </summary>
        public string Path;
        /// <summary>
        /// 下载成功回调。
        /// </summary>
        public Action SuccessCallback;
        /// <summary>
        /// 下载进度回调。
        /// </summary>
        public Action<float> ProgressCallback;
        /// <summary>
        /// 下载失败回调。
        /// </summary>
        public Action failureCallback;
    }

    /// <summary>
    /// 多下载任务的信息类。
    /// </summary>
    public struct MultiDownloadTaskInfo
    {
        /// <summary>
        /// 任务名字。
        /// </summary>
        public string TaskName;
        /// <summary>
        /// 统一资源定位符。
        /// </summary>
        public string Url;
        /// <summary>
        /// 保存路径。
        /// </summary>
        public string Path;
        /// <summary>
        /// 下载成功回调。
        /// </summary>
        public Action<string> SuccessCallback;
        /// <summary>
        /// 下载进度回调。
        /// </summary>
        public Action<string, float> ProgressCallback;
        /// <summary>
        /// 下载失败回调。
        /// </summary>
        public Action<string> failureCallback;
    }

    /// <summary>
    /// HTTP协议下载器。
    /// </summary>
    public sealed class HttpDownloader
    {
        private HttpDownloadInfo m_HttpDownloadInfo;
        private long m_Position;
        private FileStream m_FileStream;
        private bool m_HasStop;

        public event EventHandler OnDownloadSuccess;
        public event EventHandler OnDownloadFailure;
        public event EventHandler<HttpDownloaderProgressEventArgs> OnDownloadProgress;

        public HttpDownloader(HttpDownloadInfo httpDownloadInfo)
        {
            m_HttpDownloadInfo = httpDownloadInfo;
            DownloadFileCheck();
        }

        public void StartDownload(bool webExceptionRetry = false)
        {
            try
            {
                HttpWebRequest httpWebRequest = (HttpWebRequest)HttpWebRequest.Create(m_HttpDownloadInfo.Url);
                httpWebRequest.ServicePoint.Expect100Continue = false;
                if (0L < m_Position)
                {
                    httpWebRequest.AddRange((int)m_Position);
                }


                WebResponse webResponse = httpWebRequest.GetResponse();
                Stream webResponseStream = webResponse.GetResponseStream();

                float progress = 0f;
                long currentSize = m_Position;
                long totalSize = m_Position + webResponse.ContentLength;

                byte[] btContent = new byte[m_HttpDownloadInfo.DownloadBufferUnit];
                int readSize = 0;
                while (!m_HasStop && 0 < (readSize = webResponseStream.Read(btContent, 0, m_HttpDownloadInfo.DownloadBufferUnit)))
                {
                    progress = (float)(currentSize += readSize) / totalSize;
                    if (null != OnDownloadProgress)
                    {
                        OnDownloadProgress.Invoke(this, new HttpDownloaderProgressEventArgs(progress));
                    }
                    m_FileStream.Flush();
                    m_FileStream.Write(btContent, 0, readSize);

                    System.Threading.Thread.Sleep(10);
                    //                    System.Console.SetCursorPosition(0,Thread.CurrentThread.ManagedThreadId);
                    //                    System.Console.WriteLine(Thread.CurrentThread.ManagedThreadId+"    "+DateTime.Now.Second);

                }
                m_FileStream.Close();
                webResponseStream.Close();

                if (!m_HasStop)
                {
                    ReNameTempFile();

                    if (null != OnDownloadSuccess)
                    {
                        OnDownloadSuccess.Invoke(this, EventArgs.Empty);
                    }
                }
            }
            catch (Exception ex)
            {
                if (null != OnDownloadFailure)
                {
                    OnDownloadFailure.Invoke(this, EventArgs.Empty);
                }

                if (ex is System.Net.WebException && webExceptionRetry)
                {
                    StartDownload();
                }
            }
        }


        public void StopDownload()
        {
            m_HasStop = true;
        }

        private void DownloadFileCheck()
        {
            var tmpFileName = m_HttpDownloadInfo.SavePath + m_HttpDownloadInfo.TempFileExtension;
            if (File.Exists(tmpFileName))
            {
                m_FileStream = File.OpenWrite(tmpFileName);
                m_Position = m_FileStream.Length;
                m_FileStream.Seek(m_Position, SeekOrigin.Current);
            }
            else
            {
                m_FileStream = new FileStream(tmpFileName, FileMode.Create);
                m_Position = 0L;
            }
        }

        private void ReNameTempFile()
        {
            if (File.Exists(m_HttpDownloadInfo.SavePath + m_HttpDownloadInfo.TempFileExtension))
            {
                if (File.Exists(m_HttpDownloadInfo.SavePath))
                {
                    File.Delete(m_HttpDownloadInfo.SavePath);
                }

                FileInfo fileInfo = new FileInfo(m_HttpDownloadInfo.SavePath + m_HttpDownloadInfo.TempFileExtension);
                fileInfo.MoveTo(m_HttpDownloadInfo.SavePath);
                //File.Move(m_HttpDownloadInfo.SavePath + m_HttpDownloadInfo.TempFileExtension, m_HttpDownloadInfo.SavePath);
            }
        }

    }

    /// <summary>
    /// HTTP下载器进度事件参数类。
    /// </summary>
    public sealed class HttpDownloaderProgressEventArgs : EventArgs
    {
        public HttpDownloaderProgressEventArgs(float progress)
        {
            DownloadProgress = progress;
        }

        public float DownloadProgress { get; private set; }
    }

    /// <summary>
    /// HTTP下载信息。
    /// </summary>
    public sealed class HttpDownloadInfo
    {
        public string Url;
        public string SavePath;
        public string TempFileExtension;
        public int DownloadBufferUnit = 512;
    }

#endregion
            
        }
    }




}
