//----------------------------------------------------
//Copyright © 2008-2017 Mr-Alan. All rights reserved.
//Mail: Mr.Alan.China@[outlook|gmail].com
//Website: www.0x69h.com
//----------------------------------------------------


namespace BlackFire.Unity
{
    /// <summary>
    /// 字节相关数据类型扩展
    /// </summary>
    public static class ByteExtension
    {
        public static byte[] Clear(this byte[] byteArray)
        {
            if (null == byteArray) return null;
            for (int i = 0; i < byteArray.Length; i++)
            {
                byteArray[i] = 0;
            }
            return byteArray;
        }
    }
}
