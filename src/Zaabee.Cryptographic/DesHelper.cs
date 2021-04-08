using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Zaabee.Cryptographic
{
    /// <summary>
    /// DES Helper
    /// </summary>
    public static class DesHelper
    {
        public static Encoding Encoding { get; set; } = Encoding.UTF8;

        /// <summary>
        /// DES Encrypt
        /// </summary>
        /// <param name="original"></param>
        /// <param name="key"></param>
        /// <param name="vector"></param>
        /// <param name="cipherMode"></param>
        /// <param name="paddingMode"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static byte[] Encrypt(string original, string key, string vector = null,
            CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.PKCS7,
            Encoding encoding = null)
        {
            if (original is null) throw new ArgumentNullException(nameof(original));
            if (key is null) throw new ArgumentNullException(nameof(key));
            encoding ??= Encoding;
            var bKey = encoding.GetBytes(key);
            var bVector = vector is null ? null : encoding.GetBytes(vector);
            return Encrypt(original, bKey, bVector, cipherMode, paddingMode);
        }

        /// <summary>
        /// DES Encrypt
        /// </summary>
        /// <param name="original"></param>
        /// <param name="key"></param>
        /// <param name="vector"></param>
        /// <param name="cipherMode"></param>
        /// <param name="paddingMode"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public static byte[] Encrypt(string original, byte[] key, byte[] vector = null,
            CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.PKCS7)
        {
            if (original is null) throw new ArgumentNullException(nameof(original));
            if (key is null) throw new ArgumentNullException(nameof(key));
            Array.Resize(ref key, 8);
            if (vector is not null) Array.Resize(ref vector, 8);
            using (var des = DES.Create())
            {
                if (des is null) throw new NotSupportedException(nameof(des));
                des.Mode = cipherMode;
                des.Padding = paddingMode;
                using (var encryptor = des.CreateEncryptor(key, vector ?? des.IV))
                using (var msEncrypt = new MemoryStream())
                using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
                {
                    using (var swEncrypt = new StreamWriter(csEncrypt))
                        swEncrypt.Write(original);
                    return msEncrypt.ToArray();
                }
            }
        }

        /// <summary>
        /// DES Decrypt
        /// </summary>
        /// <param name="encrypted"></param>
        /// <param name="key"></param>
        /// <param name="vector"></param>
        /// <param name="cipherMode"></param>
        /// <param name="paddingMode"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        public static string Decrypt(byte[] encrypted, string key, string vector = null,
            CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.PKCS7,
            Encoding encoding = null)
        {
            if (encrypted is null) throw new ArgumentNullException(nameof(encrypted));
            if (key is null) throw new ArgumentNullException(nameof(key));
            encoding ??= Encoding;
            var bKey = encoding.GetBytes(key);
            var bVector = vector is null ? null : encoding.GetBytes(vector);
            return Decrypt(encrypted, bKey, bVector, cipherMode, paddingMode);
        }

        /// <summary>
        /// DES Decrypt
        /// </summary>
        /// <param name="encrypted"></param>
        /// <param name="key"></param>
        /// <param name="vector"></param>
        /// <param name="cipherMode"></param>
        /// <param name="paddingMode"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public static string Decrypt(byte[] encrypted, byte[] key, byte[] vector = null,
            CipherMode cipherMode = CipherMode.CBC, PaddingMode paddingMode = PaddingMode.PKCS7)
        {
            if (encrypted is null) throw new ArgumentNullException(nameof(encrypted));
            if (key is null) throw new ArgumentNullException(nameof(key));
            Array.Resize(ref key, 8);
            if (vector is not null) Array.Resize(ref vector, 8);
            using (var des = DES.Create())
            {
                if (des is null) throw new NotSupportedException(nameof(des));
                des.Mode = cipherMode;
                des.Padding = paddingMode;
                using (var decryptor = des.CreateDecryptor(key, vector ?? des.IV))
                using (var msDecrypt = new MemoryStream(encrypted))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new StreamReader(csDecrypt))
                    return srDecrypt.ReadToEnd();
            }
        }
    }
}