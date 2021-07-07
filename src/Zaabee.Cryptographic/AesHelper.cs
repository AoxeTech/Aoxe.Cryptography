using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Zaabee.Cryptographic
{
    /// <summary>
    /// AES helper
    /// </summary>
    public static class AesHelper
    {
        public static Encoding Encoding { get; set; } = Encoding.UTF8;

        /// <summary>
        /// AES Encrypt
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
            var bKey = (encoding ?? Encoding).GetBytes(key);
            var bVector = vector is null ? null : (encoding ?? Encoding).GetBytes(vector);
            return Encrypt(original, bKey, bVector, cipherMode, paddingMode);
        }

        /// <summary>
        /// AES Encrypt
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
            Array.Resize(ref key, 32);
            if (vector is not null) Array.Resize(ref vector, 16);
            using (var aes = Aes.Create())
            {
                if (aes is null) throw new NotSupportedException(nameof(aes));
                aes.Mode = cipherMode;
                aes.Padding = paddingMode;
                using (var encryptor = aes.CreateEncryptor(key, vector ?? aes.IV))
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
        /// AES Decrypt
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
            var bKey = (encoding ?? Encoding).GetBytes(key);
            var bVector = vector is null ? null : (encoding ?? Encoding).GetBytes(vector);
            return Decrypt(encrypted, bKey, bVector, cipherMode, paddingMode);
        }

        /// <summary>
        /// AES Decrypt
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
            Array.Resize(ref key, 32);
            if (vector is not null) Array.Resize(ref vector, 16);
            using (var aes = Aes.Create())
            {
                if (aes is null) throw new NotSupportedException(nameof(aes));
                aes.Mode = cipherMode;
                aes.Padding = paddingMode;
                using (var decryptor = aes.CreateDecryptor(key, vector ?? aes.IV))
                using (var msDecrypt = new MemoryStream(encrypted))
                using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
                using (var srDecrypt = new StreamReader(csDecrypt))
                    return srDecrypt.ReadToEnd();
            }
        }
    }
}