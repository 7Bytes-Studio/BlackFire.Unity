/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;

namespace BlackFire.Unity.Editor
{
    public sealed class HttpDownloaderProgressEventArgs : EventArgs
    {
        public HttpDownloaderProgressEventArgs(float progress)
        {
            DownloadProgress=progress;
        }

        public float DownloadProgress { get; private set; }
    }

}
