using System;
using System.Security.Cryptography;
using System.Text;

namespace Zaabee.Cryptographic
{
    public static class Md5Helper
    {
        public static Encoding Encoding { get; set; } = Encoding.UTF8;

        /// <summary>
        /// Get MD5 hash string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string GetMd5HashString(string str, Encoding encoding = null) =>
            GetMd5HashString((encoding ?? Encoding).GetBytes(str));

        /// <summary>
        /// Get MD5 hash string
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public static string GetMd5HashString(byte[] bytes)
        {
            var hashBytes = GetMd5HashBytes(bytes);
            return BitConverter.ToString(hashBytes);
        }

        /// <summary>
        /// Get MD5 hash bytes
        /// </summary>
        /// <param name="str"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static byte[] GetMd5HashBytes(string str, Encoding encoding = null) =>
            GetMd5HashBytes((encoding ?? Encoding).GetBytes(str));

        /// <summary>
        /// Get MD5 hash bytes
        /// </summary>
        /// <param name="bytes"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public static byte[] GetMd5HashBytes(byte[] bytes)
        {
            using var md5 = MD5.Create();
            if (md5 is null) throw new NotSupportedException(nameof(md5));
            return md5.ComputeHash(bytes);
        }
    }
}