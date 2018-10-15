/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using BlackFire.Unity.Network;

namespace BlackFire.Unity
{
    public sealed partial class NetworkManager
    {
        public DownloadTaskInfo GetDownloadTask(string taskName)
        {
           return m_DownloadModule.GetDownloadTask(taskName);
        }

        public bool HasTaskDone(string taskName)
        {
            return m_DownloadModule.HasTaskDone(taskName);
        }


        public void StartDownloadTask(DownloadTaskInfo downloadTaskInfo)
        {
            m_DownloadModule.StartDownloadTask(downloadTaskInfo);
        }

        public void StopDownloadTask(string taskName)
        {
            m_DownloadModule.StopDownloadTask(taskName);
        }
    }
}
