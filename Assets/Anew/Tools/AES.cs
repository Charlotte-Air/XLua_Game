using UnityEngine;
using System.Collections;
using System.Security.Cryptography;
using System.IO;
using System.Text;
using System;

public class AES
 {
        /// <summary>
        /// 获取密钥
        /// </summary>
        private static string Key
        {
            get { return "ABCDEFGHIJKLMNOP"; }
        }

        /// <summary>
        /// 获取向量
        /// </summary>
        private static string IV
        {
            get { return "PONMLKJIHGFEDCBA"; }
        }

        /// <summary>
        /// AES加密
        /// </summary>
        /// <returns>密文</returns>
        public static byte[] AESEncrypt(byte[] content)
        {
            byte[] bKey = Encoding.UTF8.GetBytes(Key);
            byte[] bIV = Encoding.UTF8.GetBytes(IV);
            byte[] byteArray = content;

            byte[] encrypt = null;
            Rijndael aes = Rijndael.Create();
            aes.Mode = CipherMode.CFB;
            aes.KeySize = 128;
            aes.Padding = PaddingMode.PKCS7;
        
            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateEncryptor(bKey, bIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(byteArray, 0, byteArray.Length);
                        cStream.FlushFinalBlock();
                        encrypt = mStream.ToArray();
                    }
                }
            }
            catch (Exception e)
            {
                Debug.Log(e);
            }
            aes.Clear();

            return encrypt;
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <returns>明文</returns>
        public static byte[] AESDecrypt(byte[] content)
        {
            byte[] bKey = Encoding.UTF8.GetBytes(Key);
            byte[] bIV = Encoding.UTF8.GetBytes(IV);
            byte[] byteArray = content;

            byte[] decrypt = null;
            Rijndael aes = Rijndael.Create();
            aes.Mode = CipherMode.CFB;
            aes.KeySize = 128;
            aes.Padding = PaddingMode.PKCS7;
            try
            {
                using (MemoryStream mStream = new MemoryStream())
                {
                    using (CryptoStream cStream = new CryptoStream(mStream, aes.CreateDecryptor(bKey, bIV), CryptoStreamMode.Write))
                    {
                        cStream.Write(byteArray, 0, byteArray.Length);
                        cStream.FlushFinalBlock();
                        decrypt = mStream.ToArray();
                    }
                }
            }
            catch(Exception e) 
            {
                Debug.Log(e);
            }
            aes.Clear();

            return decrypt;
        }

        ///// <summary>
        ///// AES解密
        ///// </summary>
        ///// <param name="encryptStr">密文字符串</param>
        ///// <param name="returnNull">解密失败时是否返回 null，false 返回 String.Empty</param>
        ///// <returns>明文</returns>
        //public static string AESDecrypt(string encryptStr, bool returnNull)
        //{
        //    string decrypt = AESDecrypt(encryptStr);
        //    return returnNull ? decrypt : (decrypt == null ? String.Empty : decrypt);
        //}
   }


