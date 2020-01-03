using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Zaabee.Cryptographic
{
    /// <summary>
    /// AES helper
    /// </summary>
    public class AesHelper
    {
        /// <summary>
        /// AES Encrypt
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="key">密钥（只截取/补全32个字节）</param>
        /// <param name="vector">向量（只截取/补全16个字节）</param>
        /// <param name="encoding">字符编码</param>
        /// <returns></returns>
        public byte[] Encrypt(string str, string key, string vector, Encoding encoding)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (vector == null) throw new ArgumentNullException(nameof(vector));
            if (encoding == null) throw new ArgumentNullException(nameof(encoding));
            var bKey = new byte[32];
            Array.Copy(encoding.GetBytes(key.PadRight(bKey.Length)), bKey, bKey.Length);
            var bVector = new byte[16];
            Array.Copy(encoding.GetBytes(vector.PadRight(bVector.Length)), bVector, bVector.Length);
            return Encrypt(str, bKey, bVector);
        }

        /// <summary>
        /// AES Encrypt（注意，不带向量的AES加密的块密码模式要使用CipherMode.ECB，存在安全隐患）
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="key">密钥（只截取/补全32个字节）</param>
        /// <param name="encoding">字符编码</param>
        /// <returns></returns>
        public byte[] Encrypt(string str, string key, Encoding encoding)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (encoding == null) throw new ArgumentNullException(nameof(encoding));
            var bKey = new byte[32];
            Array.Copy(encoding.GetBytes(key.PadRight(bKey.Length)), bKey, bKey.Length);
            return Encrypt(str, bKey);
        }

        /// <summary>
        /// AES Encrypt
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="key">密钥（只截取/补全32个字节）</param>
        /// <param name="vector">向量（只截取/补全16个字节）</param>
        /// <returns></returns>
        public byte[] Encrypt(string str, byte[] key, byte[] vector)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (vector == null) throw new ArgumentNullException(nameof(vector));
            using (var aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = key;
                aesAlg.IV = vector;
                var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
                using (var msEncrypt = new MemoryStream())
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                        swEncrypt.Write(str);
                    return msEncrypt.ToArray();
                }
            }
        }

        /// <summary>
        /// AES Encrypt（注意，不带向量的AES加密的块密码模式要使用CipherMode.ECB，存在安全隐患）
        /// </summary>
        /// <param name="str">字符串</param>
        /// <param name="key">密钥（只截取/补全32个字节）</param>
        /// <returns></returns>
        public byte[] Encrypt(string str, byte[] key)
        {
            if (str == null) throw new ArgumentNullException(nameof(str));
            if (key == null) throw new ArgumentNullException(nameof(key));
            using (var aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = key;
                aesAlg.Mode = CipherMode.ECB;
                var encryptor = aesAlg.CreateEncryptor();
                using (var msEncrypt = new MemoryStream())
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                        swEncrypt.Write(str);
                    return msEncrypt.ToArray();
                }
            }
        }

        /// <summary>
        /// AES Decrypt
        /// </summary>
        /// <param name="ciphertext">密文</param>
        /// <param name="key">密钥（只截取/补全32个字节）</param>
        /// <param name="vector">向量（只截取/补全16个字节）</param>
        /// <param name="encoding">字符编码</param>
        /// <returns></returns>
        public string Decrypt(byte[] ciphertext, string key, string vector, Encoding encoding)
        {
            if (ciphertext == null) throw new ArgumentNullException(nameof(ciphertext));
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (vector == null) throw new ArgumentNullException(nameof(vector));
            if (encoding == null) throw new ArgumentNullException(nameof(encoding));
            var bKey = new byte[32];
            Array.Copy(encoding.GetBytes(key.PadRight(bKey.Length)), bKey, bKey.Length);
            var bVector = new byte[16];
            Array.Copy(encoding.GetBytes(vector.PadRight(bVector.Length)), bVector, bVector.Length);
            return Decrypt(ciphertext, bKey, bVector);
        }

        /// <summary>
        /// AES Decrypt（注意，不带向量的AES加密的块密码模式要使用CipherMode.ECB，存在安全隐患）
        /// </summary>
        /// <param name="ciphertext">密文</param>
        /// <param name="key">密钥（只截取/补全32个字节）</param>
        /// <param name="encoding">字符编码</param>
        /// <returns></returns>
        public string Decrypt(byte[] ciphertext, string key, Encoding encoding)
        {
            if (ciphertext == null) throw new ArgumentNullException(nameof(ciphertext));
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (encoding == null) throw new ArgumentNullException(nameof(encoding));
            var bKey = new byte[32];
            Array.Copy(encoding.GetBytes(key.PadRight(bKey.Length)), bKey, bKey.Length);
            return Decrypt(ciphertext, bKey);
        }

        /// <summary>
        /// AES Decrypt
        /// </summary>
        /// <param name="ciphertext">密文</param>
        /// <param name="key">密钥（只截取/补全32个字节）</param>
        /// <param name="vector">向量（只截取/补全16个字节）</param>
        /// <returns></returns>
        public string Decrypt(byte[] ciphertext, byte[] key, byte[] vector)
        {
            if (ciphertext == null) throw new ArgumentNullException(nameof(ciphertext));
            if (key == null) throw new ArgumentNullException(nameof(key));
            if (vector == null) throw new ArgumentNullException(nameof(vector));
            using (var aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = key;
                aesAlg.IV = vector;
                var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
                using (var msDecrypt = new MemoryStream(ciphertext))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new StreamReader(csDecrypt))
                    return srDecrypt.ReadToEnd();
            }
        }

        /// <summary>
        /// AES Decrypt（注意，不带向量的AES加密的块密码模式要使用CipherMode.ECB，存在安全隐患）
        /// </summary>
        /// <param name="ciphertext">密文</param>
        /// <param name="key">密钥（只截取/补全32个字节）</param>
        /// <returns></returns>
        public string Decrypt(byte[] ciphertext, byte[] key)
        {
            if (ciphertext == null) throw new ArgumentNullException(nameof(ciphertext));
            if (key == null) throw new ArgumentNullException(nameof(key));
            using (var aesAlg = new AesCryptoServiceProvider())
            {
                aesAlg.Key = key;
                aesAlg.Mode = CipherMode.ECB;
                var decryptor = aesAlg.CreateDecryptor();
                using (var msDecrypt = new MemoryStream(ciphertext))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new StreamReader(csDecrypt))
                    return srDecrypt.ReadToEnd();
            }
        }
    }
}