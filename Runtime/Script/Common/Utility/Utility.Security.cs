/*
--------------------------------------------------
| Copyright © 2008 Mr-Alan. All rights reserved. |
| Website: www.0x69h.com                         |
| Mail: mr.alan.china@gmail.com                  |
| QQ: 835988221                                  |
--------------------------------------------------
*/

using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;
using UnityEngine;

namespace BlackFire.Unity
{
    public static partial class Utility
    {
        /// <summary>
        /// 安全辅助类。
        /// </summary>
        public static class Security
        {


            #region AES
            
                /// <summary>
                /// AES算法加密字符串。
                /// </summary>
                /// <param name="original">源字符串。</param>
                /// <param name="password">解密密码。(32 | 16)</param>
                /// <returns>加密字符串。</returns>
                public static string AES_Encrypt(string original,string password)
                {
                    if (string.IsNullOrEmpty(original)) return null;
                    Byte[] toEncryptArray = Encoding.UTF8.GetBytes(original);

                    RijndaelManaged rm = new RijndaelManaged
                    {
                        Key = Encoding.UTF8.GetBytes(password),
                        Mode = CipherMode.ECB,
                        Padding = PaddingMode.PKCS7
                    };

                    ICryptoTransform cTransform = rm.CreateEncryptor();
                    Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);

                    return Convert.ToBase64String(resultArray, 0, resultArray.Length);
                }
    
                /// <summary>
                ///  AES算法解密字符串。
                /// </summary>
                /// <param name="cipherText">加密字符串。</param>
                /// <param name="password">解密密码。(32 | 16)</param>
                /// <returns>解密后的明文字符串。</returns>
                public static string AES_Decrypt(string cipherText,string password)
                {
                    if (string.IsNullOrEmpty(cipherText)) return null;
                    Byte[] toEncryptArray = Convert.FromBase64String(cipherText);

                    RijndaelManaged rm = new RijndaelManaged
                    {
                        Key = Encoding.UTF8.GetBytes(password),
                        Mode = CipherMode.ECB,
                        Padding = PaddingMode.PKCS7
                    };

                    ICryptoTransform cTransform = rm.CreateDecryptor();
                    Byte[] resultArray = cTransform.TransformFinalBlock(toEncryptArray, 0, toEncryptArray.Length);
                    
                    return Encoding.UTF8.GetString(resultArray);
                }

            

            #endregion
            


        }
        
        
        

       
        
        
        
        
        
    }
}
