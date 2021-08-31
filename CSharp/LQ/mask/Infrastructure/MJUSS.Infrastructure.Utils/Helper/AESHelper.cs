using MJUSS.Infrastructure.Core.Constants;
using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace MJUSS.Infrastructure.Utils.Helper
{
    public class AESHelper
    {
        /// <summary>
        /// AES加密
        /// </summary>
        /// <param name="Data">被加密的明文</param>
        /// <returns>密文</returns>
        public static string AESEncrypt(string Data)
        {
            string Key = AESConstants.AESH5UrlKey;
            string Vector = AESConstants.AESH5UrlIV;
            byte[] plainBytes = Encoding.UTF8.GetBytes(Data);

            byte[] bKey = new byte[32];
            Array.Copy(Encoding.UTF8.GetBytes(Key.PadRight(bKey.Length)), bKey, bKey.Length);
            byte[] bVector = new byte[16];
            Array.Copy(Encoding.UTF8.GetBytes(Vector.PadRight(bVector.Length)), bVector, bVector.Length);
            byte[] Cryptograph = null;
            using (Rijndael Aes = Rijndael.Create())
            {
                try
                {
                    using (MemoryStream Memory = new MemoryStream())
                    {
                        using (CryptoStream Encryptor = new CryptoStream(Memory,Aes.CreateEncryptor(bKey, bVector),CryptoStreamMode.Write))
                        {
                            Encryptor.Write(plainBytes, 0, plainBytes.Length);
                            Encryptor.FlushFinalBlock();
                            Cryptograph = Memory.ToArray();
                        }
                    }
                }
                catch
                {
                    Cryptograph = null;
                }
            }
            return Convert.ToBase64String(Cryptograph);
        }

        /// <summary>
        /// AES解密
        /// </summary>
        /// <param name="Data">被解密的密文</param>
        /// <returns>明文</returns>
        public static string AESDecrypt(string Data)
        {
            string Key = AESConstants.AESH5UrlKey;
            string Vector = AESConstants.AESH5UrlIV;
            byte[] encryptedBytes = Convert.FromBase64String(Data.Replace(' ', '+'));
            byte[] bKey = new byte[32];
            Array.Copy(Encoding.UTF8.GetBytes(Key.PadRight(bKey.Length)), bKey, bKey.Length);
            byte[] bVector = new byte[16];
            Array.Copy(Encoding.UTF8.GetBytes(Vector.PadRight(bVector.Length)), bVector, bVector.Length);
            byte[] original = null;
            using (Rijndael Aes = Rijndael.Create())
            {
                try
                {
                    using (MemoryStream Memory = new MemoryStream(encryptedBytes))
                    {
                        using (CryptoStream Decryptor = new CryptoStream(Memory,Aes.CreateDecryptor(bKey, bVector),CryptoStreamMode.Read))
                        {
                            using (MemoryStream originalMemory = new MemoryStream())
                            {
                                byte[] Buffer = new byte[1024];
                                int readBytes = 0;
                                while ((readBytes = Decryptor.Read(Buffer, 0, Buffer.Length)) > 0)
                                {
                                    originalMemory.Write(Buffer, 0, readBytes);
                                }

                                original = originalMemory.ToArray();
                            }
                        }
                    }
                }
                catch
                {
                    original = null;
                }
            }
            return Encoding.UTF8.GetString(original);
        }

    }
}
