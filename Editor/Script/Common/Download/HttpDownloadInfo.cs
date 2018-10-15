/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

namespace BlackFire.Unity.Editor
{
    public sealed class HttpDownloadInfo
    {
        public string Url;
        public string SavePath;
        public string TempFileExtension;
        public int DownloadBufferUnit = 512;
    }
}
