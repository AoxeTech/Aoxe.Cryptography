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

        /// <summary>
        /// Get SHA1 hash string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludHyphen"></param>
        /// <returns></returns>
        public static string ToSha1(this string str, bool isUpper = true, bool isIncludHyphen = false)
        {
            return Sha1(str, isUpper, isIncludHyphen);
        }

        /// <summary>
        /// SHA1 hash
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludHyphen"></param>
        /// <returns></returns>
        public static string Sha1(string str, bool isUpper = true, bool isIncludHyphen = false)
        {
            return Sha1(Encoding.UTF8.GetBytes(str), isUpper, isIncludHyphen);
        }

        /// <summary>
        /// SHA1 hash
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludHyphen"></param>
        /// <returns></returns>
        public static string Sha1(byte[] bytes, bool isUpper = true, bool isIncludHyphen = false)
        {
            using (var sha1 = SHA1.Create())
                bytes = sha1.ComputeHash(bytes);
            var str = BitConverter.ToString(bytes);
            str = isUpper ? str.ToUpper() : str.ToLower();
            str = isIncludHyphen ? str : str.Replace("-", "");
            return str;
        }

        #endregion

        #region SHA256

        /// <summary>
        /// Get SHA256 hash string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludHyphen"></param>
        /// <returns></returns>
        public static string ToSha256(this string str, bool isUpper = true, bool isIncludHyphen = false)
        {
            return Sha256(str, isUpper, isIncludHyphen);
        }

        /// <summary>
        /// SHA256 hash
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludHyphen"></param>
        /// <returns></returns>
        public static string Sha256(string str, bool isUpper = true, bool isIncludHyphen = false)
        {
            return Sha256(Encoding.UTF8.GetBytes(str), isUpper, isIncludHyphen);
        }

        /// <summary>
        /// SHA256 hash
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludHyphen"></param>
        /// <returns></returns>
        public static string Sha256(byte[] bytes, bool isUpper = true, bool isIncludHyphen = false)
        {
            using (var sha1 = SHA256.Create())
                bytes = sha1.ComputeHash(bytes);
            var str = BitConverter.ToString(bytes);
            str = isUpper ? str.ToUpper() : str.ToLower();
            str = isIncludHyphen ? str : str.Replace("-", "");
            return str;
        }

        #endregion

        #region SHA384

        /// <summary>
        /// Get SHA384 hash string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludHyphen"></param>
        /// <returns></returns>
        public static string ToSha384(this string str, bool isUpper = true, bool isIncludHyphen = false)
        {
            return Sha384(str, isUpper, isIncludHyphen);
        }

        /// <summary>
        /// SHA384 hash
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludHyphen"></param>
        /// <returns></returns>
        public static string Sha384(string str, bool isUpper = true, bool isIncludHyphen = false)
        {
            return Sha384(Encoding.UTF8.GetBytes(str), isUpper, isIncludHyphen);
        }

        /// <summary>
        /// SHA384 hash
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludHyphen"></param>
        /// <returns></returns>
        public static string Sha384(byte[] bytes, bool isUpper = true, bool isIncludHyphen = false)
        {
            using (var sha1 = SHA384.Create())
                bytes = sha1.ComputeHash(bytes);
            var str = BitConverter.ToString(bytes);
            str = isUpper ? str.ToUpper() : str.ToLower();
            str = isIncludHyphen ? str : str.Replace("-", "");
            return str;
        }

        #endregion

        #region SHA512

        /// <summary>
        /// Get SHA512 hash string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludHyphen"></param>
        /// <returns></returns>
        public static string ToSha512(this string str, bool isUpper = true, bool isIncludHyphen = false)
        {
            return Sha512(str, isUpper, isIncludHyphen);
        }

        /// <summary>
        /// SHA512 hash
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludHyphen"></param>
        /// <returns></returns>
        public static string Sha512(string str, bool isUpper = true, bool isIncludHyphen = false)
        {
            return Sha512(Encoding.UTF8.GetBytes(str), isUpper, isIncludHyphen);
        }

        /// <summary>
        /// SHA512 hash
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludHyphen"></param>
        /// <returns></returns>
        public static string Sha512(byte[] bytes, bool isUpper = true, bool isIncludHyphen = false)
        {
            using (var sha1 = SHA512.Create())
                bytes = sha1.ComputeHash(bytes);
            var str = BitConverter.ToString(bytes);
            str = isUpper ? str.ToUpper() : str.ToLower();
            str = isIncludHyphen ? str : str.Replace("-", "");
            return str;
        }

        #endregion
    }
}