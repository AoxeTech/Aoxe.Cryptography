using System;
using System.Security.Cryptography;
using System.Text;

namespace Zaabee.Cryptographic
{
    public static class Md5Helper
    {
        #region MD5

        public static byte[] Md5(this byte[] bytes)
        {
            if (bytes == null) throw new ArgumentNullException(nameof(bytes));
            using (var provider = MD5.Create())
                return provider.ComputeHash(bytes);
        }

        #endregion

        #region 32 bit MD5

        /// <summary>
        /// Get 32bit MD5 hash string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludeHyphen"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string To32Md5(this string str, bool isUpper = true, bool isIncludeHyphen = false,
            Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            return To32Md5(encoding.GetBytes(str), isUpper, isIncludeHyphen);
        }

        /// <summary>
        /// 32bit MD5 hash
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludeHyphen"></param>
        /// <returns></returns>
        public static string To32Md5(this byte[] bytes, bool isUpper = true, bool isIncludeHyphen = false)
        {
            var hashBytes = bytes.Md5();
            var str = BitConverter.ToString(hashBytes);
            str = isUpper ? str.ToUpper() : str.ToLower();
            str = isIncludeHyphen ? str : str.Replace("-", "");
            return str;
        }

        #endregion

        #region 16 bit MD5

        /// <summary>
        /// Get 16bit MD5 hash string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludeHyphen"></param>
        /// <param name="encoding"></param>
        /// <returns></returns>
        public static string To16Md5(this string str, bool isUpper = true, bool isIncludeHyphen = false,
            Encoding encoding = null)
        {
            encoding = encoding ?? Encoding.UTF8;
            return To16Md5(encoding.GetBytes(str), isUpper, isIncludeHyphen);
        }

        /// <summary>
        /// Get 16bit MD5 hash string
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludeHyphen"></param>
        /// <returns></returns>
        public static string To16Md5(this byte[] bytes, bool isUpper = true, bool isIncludeHyphen = false)
        {
            var hashBytes = bytes.Md5();
            var str = BitConverter.ToString(hashBytes, 4, 8);
            str = isUpper ? str.ToUpper() : str.ToLower();
            str = isIncludeHyphen ? str : str.Replace("-", "");
            return str;
        }

        #endregion
    }
}