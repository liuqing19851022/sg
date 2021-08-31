
namespace MJUSS.Infrastructure.Utils.Certificate
{
    using System;
    using System.Linq;
    using System.Security.Cryptography;
    using System.Security.Cryptography.X509Certificates;
    using System.Text;

    public class X509CertificateHelper
    {
        /// <summary>     
        /// 到存储区获取X509证书     
        /// </summary>     
        /// <param name="subjectName">名称</param>     
        /// <returns></returns>     
        public static X509Certificate2 GetCertificateFromStore(string subjectName)
        {
            var store = new X509Store(StoreLocation.LocalMachine);
            store.Open(OpenFlags.ReadOnly);
            var storecollection = store.Certificates;
            foreach (var x509 in storecollection.Cast<X509Certificate2>().Where(x509 => x509.Subject == subjectName))
            {
                return x509;
            }
            store.Close();
            return null;
        }
        /// <summary>
        /// 获取指定X509证书的公钥
        /// </summary>
        /// <param name="cert"></param>
        /// <returns></returns>
        public static string GetPublicKeyFromX509Cert(X509Certificate2 cert)
        {
            return cert?.PublicKey.Key.ToXmlString(false) ?? string.Empty;
        }
        /// <summary>
        /// /// 获取指定X509证书的公钥私钥
        /// </summary>
        /// <param name="cert"></param>
        /// <returns></returns>
        public static string GetPrivateKeyFromX509Cert(X509Certificate2 cert)
        {
            return cert?.PrivateKey.ToXmlString(true) ?? string.Empty;
        }
        /// <summary>
        /// RSA解密
        /// </summary>
        /// <param name="xmlPrivateKey"></param>
        /// <param name="m_strDecryptString"></param>
        /// <returns></returns>
        public static string RSADecrypt(string xmlPrivateKey, string m_strDecryptString)     
        {     
            var provider = new RSACryptoServiceProvider();     
            provider.FromXmlString(xmlPrivateKey);     
            var rgb = Convert.FromBase64String(m_strDecryptString);     
            var bytes = provider.Decrypt(rgb, false);     
            return new UnicodeEncoding().GetString(bytes);     
        }

        /// <summary>     
        /// RSA加密     
        /// </summary>     
        /// <param name="xmlPublicKey"></param>     
        /// <param name="m_strEncryptString"></param>     
        /// <returns></returns>     
        public static string RSAEncrypt(string xmlPublicKey, string m_strEncryptString)
        {
            var provider = new RSACryptoServiceProvider();
            provider.FromXmlString(xmlPublicKey);
            var bytes = new UnicodeEncoding().GetBytes(m_strEncryptString);
            return Convert.ToBase64String(provider.Encrypt(bytes, false));     
        }

        /// <summary>
        /// 获取指定公钥证书的加密数据
        /// </summary>
        /// <param name="publicCertFilePath">公钥证书路径</param>
        /// <param name="data">数据</param>
        /// <returns></returns>
        public static string GetEncryptDataWithCert(string publicCertFilePath, string data)
        {
            var x509Certificate2 = new X509Certificate2(publicCertFilePath);
            return RSAEncrypt(GetPublicKeyFromX509Cert(x509Certificate2),data);
        }
        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="p_strKeyPrivate">私钥</param>
        /// <param name="m_strHashbyteSignature">需签名的数据</param>
        /// <returns>签名后的值</returns>
        public string SignatureFormatter(string p_strKeyPrivate, string m_strHashbyteSignature)
        {
            var rgbHash = Convert.FromBase64String(m_strHashbyteSignature);
            var key = new RSACryptoServiceProvider();
            key.FromXmlString(p_strKeyPrivate);
            var formatter = new RSAPKCS1SignatureFormatter(key);
            formatter.SetHashAlgorithm("SHA1");
            var inArray = formatter.CreateSignature(rgbHash);
            return Convert.ToBase64String(inArray);
        }

        /// <summary>
        /// 签名
        /// </summary>
        /// <param name="p_strKeyPrivate">私钥</param>
        /// <param name="dataBytes">需签名的数据</param>
        /// <returns>签名后的值</returns>
        public static byte[] SignatureFormatter(string p_strKeyPrivate, byte[] dataBytes)
        {
            var key = new RSACryptoServiceProvider();
            key.FromXmlString(p_strKeyPrivate);
            var formatter = new RSAPKCS1SignatureFormatter(key);
            formatter.SetHashAlgorithm("SHA1");

            HashAlgorithm hash = HashAlgorithm.Create("SHA1");
            byte[] hashBytes = hash.ComputeHash(dataBytes);

            return formatter.CreateSignature(hashBytes);
        }


        /// <summary>
        /// 签名验证
        /// </summary>
        /// <param name="p_strKeyPublic">公钥</param>
        /// <param name="p_strHashbyteDeformatter">待验证的用户名</param>
        /// <param name="p_strDeformatterData">注册码</param>
        /// <returns>签名是否符合</returns>
        public bool SignatureDeformatter(string p_strKeyPublic, string p_strHashbyteDeformatter, string p_strDeformatterData)
        {
            try
            {
                var rgbHash = Convert.FromBase64String(p_strHashbyteDeformatter);
                var key = new RSACryptoServiceProvider();
                key.FromXmlString(p_strKeyPublic);
                var deformatter = new RSAPKCS1SignatureDeformatter(key);
                deformatter.SetHashAlgorithm("SHA1");
                var rgbSignature = Convert.FromBase64String(p_strDeformatterData);
                return deformatter.VerifySignature(rgbHash, rgbSignature);
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// 签名验证
        /// </summary>
        /// <param name="p_strKeyPublic">公钥</param>
        /// <param name="p_strHashbyteDeformatter">待验证的数据</param>
        /// <param name="p_strDeformatterData">签名数据</param>
        /// <returns>签名是否符合</returns>
        public static bool SignatureDeformatter(string p_strKeyPublic, byte[] p_strHashbyteDeformatter, byte[] p_strDeformatterData)
        {
            try
            {
                var key = new RSACryptoServiceProvider();
                key.FromXmlString(p_strKeyPublic);
                var deformatter = new RSAPKCS1SignatureDeformatter(key);
                deformatter.SetHashAlgorithm("SHA1");

                HashAlgorithm hash = HashAlgorithm.Create("SHA1");
                byte[] hashBytes = hash.ComputeHash(p_strHashbyteDeformatter);

                return deformatter.VerifySignature(hashBytes, p_strDeformatterData);
            }
            catch
            {
                return false;
            }
        }
    }

    
}