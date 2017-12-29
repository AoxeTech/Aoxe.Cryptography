using System;
using System.Security.Cryptography;
using System.Text;

namespace Zaabee.CryptographicUtility
{
    public static class Md5Helper
    {
        #region 32位MD5

        /// <summary>
        /// Get 32bit MD5 hash string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludHyphen"></param>
        /// <returns></returns>
        public static string To32Md5(this string str, bool isUpper = true, bool isIncludHyphen = false)
        {
            return Get32Md5(str, isUpper, isIncludHyphen);
        }

        /// <summary>
        /// 32bit MD5 hash
        /// </summary>
        /// <param name="strParam"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludHyphen"></param>
        /// <returns></returns>
        public static string Get32Md5(string strParam, bool isUpper = true, bool isIncludHyphen = false)
        {
            return Get32Md5(Encoding.UTF8.GetBytes(strParam), isUpper, isIncludHyphen);
        }

        /// <summary>
        /// 32bit MD5 hash
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludHyphen"></param>
        /// <returns></returns>
        public static string Get32Md5(byte[] bytes, bool isUpper = true, bool isIncludHyphen = false)
        {
            using (var provider = MD5.Create())
                bytes = provider.ComputeHash(bytes);
            var str = BitConverter.ToString(bytes);
            str = isUpper ? str.ToUpper() : str.ToLower();
            str = isIncludHyphen ? str : str.Replace("-", "");
            return str;
        }

        #endregion

        #region 16位MD5

        /// <summary>
        /// Get 16bit MD5 hash string
        /// </summary>
        /// <param name="str"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludHyphen"></param>
        /// <returns></returns>
        public static string To16Md5(this string str, bool isUpper = true, bool isIncludHyphen = false)
        {
            return Get16Md5(str, isUpper, isIncludHyphen);
        }

        /// <summary>
        /// 16bit MD5 hash
        /// </summary>
        /// <param name="strParam"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludHyphen"></param>
        /// <returns></returns>
        public static string Get16Md5(string strParam, bool isUpper = true, bool isIncludHyphen = false)
        {
            return Get16Md5(Encoding.UTF8.GetBytes(strParam), isUpper, isIncludHyphen);
        }

        /// <summary>
        /// 16bit MD5 hash
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludHyphen"></param>
        /// <returns></returns>
        public static string Get16Md5(byte[] bytes, bool isUpper = true, bool isIncludHyphen = false)
        {
            using (var provider = MD5.Create())
                bytes = provider.ComputeHash(bytes);
            var str = BitConverter.ToString(bytes, 4, 8);
            str = isUpper ? str.ToUpper() : str.ToLower();
            str = isIncludHyphen ? str : str.Replace("-", "");
            return str;
        }

        #endregion
    }
}