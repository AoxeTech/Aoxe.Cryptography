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
        public static Encoding Encoding { get; set; } = Encoding.UTF8;

        #region SHA1

        /// <summary>
        /// Get SHA1 hash string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludeHyphen"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ComputeSha1(string str, bool isUpper = true, bool isIncludeHyphen = false,
            Encoding encoding = null)
        {
            encoding ??= Encoding;
            return ComputeSha1(encoding.GetBytes(str), isUpper, isIncludeHyphen);
        }

        /// <summary>
        /// Get SHA1 hash string
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludeHyphen"></param>
        /// <returns></returns>
        public static string ComputeSha1(byte[] bytes, bool isUpper = true, bool isIncludeHyphen = false)
        {
            using var sha1 = SHA1.Create();
            if (sha1 is null) throw new NotSupportedException(nameof(sha1));
            var hashBytes = sha1.ComputeHash(bytes);
            var str = BitConverter.ToString(hashBytes);
            str = isUpper ? str.ToUpper() : str.ToLower();
            str = isIncludeHyphen ? str : str.Replace("-", "");
            return str;
        }

        #endregion

        #region SHA256

        /// <summary>
        /// Get SHA1 hash string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludeHyphen"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ComputeSha256(string str, bool isUpper = true, bool isIncludeHyphen = false,
            Encoding encoding = null)
        {
            encoding ??= Encoding;
            return ComputeSha256(encoding.GetBytes(str), isUpper, isIncludeHyphen);
        }

        /// <summary>
        /// Get SHA1 hash string
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludeHyphen"></param>
        /// <returns></returns>
        public static string ComputeSha256(byte[] bytes, bool isUpper = true, bool isIncludeHyphen = false)
        {
            using var sha256 = SHA256.Create();
            if (sha256 is null) throw new NotSupportedException(nameof(sha256));
            var hashBytes = sha256.ComputeHash(bytes);
            var str = BitConverter.ToString(hashBytes);
            str = isUpper ? str.ToUpper() : str.ToLower();
            str = isIncludeHyphen ? str : str.Replace("-", "");
            return str;
        }

        #endregion

        #region SHA384

        /// <summary>
        /// Get SHA1 hash string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludeHyphen"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ComputeSha384(string str, bool isUpper = true, bool isIncludeHyphen = false,
            Encoding encoding = null)
        {
            encoding ??= Encoding;
            return ComputeSha384(encoding.GetBytes(str), isUpper, isIncludeHyphen);
        }

        /// <summary>
        /// Get SHA1 hash string
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludeHyphen"></param>
        /// <returns></returns>
        public static string ComputeSha384(byte[] bytes, bool isUpper = true, bool isIncludeHyphen = false)
        {
            using var sha384 = SHA384.Create();
            if (sha384 is null) throw new NotSupportedException(nameof(sha384));
            var hashBytes = sha384.ComputeHash(bytes);
            var str = BitConverter.ToString(hashBytes);
            str = isUpper ? str.ToUpper() : str.ToLower();
            str = isIncludeHyphen ? str : str.Replace("-", "");
            return str;
        }

        #endregion

        #region SHA512

        /// <summary>
        /// Get SHA1 hash string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludeHyphen"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string ComputeSha512(string str, bool isUpper = true, bool isIncludeHyphen = false,
            Encoding encoding = null)
        {
            encoding ??= Encoding;
            return ComputeSha512(encoding.GetBytes(str), isUpper, isIncludeHyphen);
        }

        /// <summary>
        /// Get SHA1 hash string
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludeHyphen"></param>
        /// <returns></returns>
        public static string ComputeSha512(byte[] bytes, bool isUpper = true, bool isIncludeHyphen = false)
        {
            using var sha512 = SHA512.Create();
            if (sha512 is null) throw new NotSupportedException(nameof(sha512));
            var hashBytes = sha512.ComputeHash(bytes);
            var str = BitConverter.ToString(hashBytes);
            str = isUpper ? str.ToUpper() : str.ToLower();
            str = isIncludeHyphen ? str : str.Replace("-", "");
            return str;
        }

        #endregion
    }
}