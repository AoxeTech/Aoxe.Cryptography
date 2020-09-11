using System;
using System.Security.Cryptography;
using System.Text;

namespace Zaabee.Cryptographic
{
    /// <summary>
    /// SHA helper
    /// </summary>
    public static class ShaHelper
    {
        #region SHA1

        public static byte[] Sha1(this byte[] bytes)
        {
            if (bytes is null) throw new ArgumentNullException(nameof(bytes));
            using (var provider = SHA1.Create())
                return provider.ComputeHash(bytes);
        }

        /// <summary>
        /// Get SHA1 hash string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludeHyphen"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToSha1(this string str, bool isUpper = true, bool isIncludeHyphen = false,
            Encoding encoding = null)
        {
            encoding ??= Encoding.UTF8;
            return ToSha1(encoding.GetBytes(str), isUpper, isIncludeHyphen);
        }

        /// <summary>
        /// Get SHA1 hash string
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludeHyphen"></param>
        /// <returns></returns>
        public static string ToSha1(this byte[] bytes, bool isUpper = true, bool isIncludeHyphen = false)
        {
            var hashBytes = bytes.Sha1();
            var str = BitConverter.ToString(hashBytes);
            str = isUpper ? str.ToUpper() : str.ToLower();
            str = isIncludeHyphen ? str : str.Replace("-", "");
            return str;
        }

        #endregion

        #region SHA256

        public static byte[] Sha256(this byte[] bytes)
        {
            if (bytes is null) throw new ArgumentNullException(nameof(bytes));
            using (var provider = SHA256.Create())
                return provider.ComputeHash(bytes);
        }

        /// <summary>
        /// Get SHA1 hash string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludeHyphen"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToSha256(this string str, bool isUpper = true, bool isIncludeHyphen = false,
            Encoding encoding = null)
        {
            encoding ??= Encoding.UTF8;
            return ToSha256(encoding.GetBytes(str), isUpper, isIncludeHyphen);
        }

        /// <summary>
        /// Get SHA1 hash string
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludeHyphen"></param>
        /// <returns></returns>
        public static string ToSha256(this byte[] bytes, bool isUpper = true, bool isIncludeHyphen = false)
        {
            var hashBytes = bytes.Sha256();
            var str = BitConverter.ToString(hashBytes);
            str = isUpper ? str.ToUpper() : str.ToLower();
            str = isIncludeHyphen ? str : str.Replace("-", "");
            return str;
        }

        #endregion

        #region SHA384

        public static byte[] Sha384(this byte[] bytes)
        {
            if (bytes is null) throw new ArgumentNullException(nameof(bytes));
            using (var provider = SHA384.Create())
                return provider.ComputeHash(bytes);
        }

        /// <summary>
        /// Get SHA1 hash string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludeHyphen"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToSha384(this string str, bool isUpper = true, bool isIncludeHyphen = false,
            Encoding encoding = null)
        {
            encoding ??= Encoding.UTF8;
            return ToSha384(encoding.GetBytes(str), isUpper, isIncludeHyphen);
        }

        /// <summary>
        /// Get SHA1 hash string
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludeHyphen"></param>
        /// <returns></returns>
        public static string ToSha384(this byte[] bytes, bool isUpper = true, bool isIncludeHyphen = false)
        {
            var hashBytes = bytes.Sha384();
            var str = BitConverter.ToString(hashBytes);
            str = isUpper ? str.ToUpper() : str.ToLower();
            str = isIncludeHyphen ? str : str.Replace("-", "");
            return str;
        }

        #endregion

        #region SHA512

        public static byte[] Sha512(this byte[] bytes)
        {
            if (bytes is null) throw new ArgumentNullException(nameof(bytes));
            using (var provider = SHA512.Create())
                return provider.ComputeHash(bytes);
        }

        /// <summary>
        /// Get SHA1 hash string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludeHyphen"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ToSha512(this string str, bool isUpper = true, bool isIncludeHyphen = false,
            Encoding encoding = null)
        {
            encoding ??= Encoding.UTF8;
            return ToSha512(encoding.GetBytes(str), isUpper, isIncludeHyphen);
        }

        /// <summary>
        /// Get SHA1 hash string
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludeHyphen"></param>
        /// <returns></returns>
        public static string ToSha512(this byte[] bytes, bool isUpper = true, bool isIncludeHyphen = false)
        {
            var hashBytes = bytes.Sha512();
            var str = BitConverter.ToString(hashBytes);
            str = isUpper ? str.ToUpper() : str.ToLower();
            str = isIncludeHyphen ? str : str.Replace("-", "");
            return str;
        }

        #endregion
    }
}