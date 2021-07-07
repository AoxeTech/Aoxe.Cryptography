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
        /// <param name="isUpper"></param>
        /// <param name="isIncludeHyphen"></param>
        /// <param name="encoding"></param>
        /// <param name="resultLength"></param>
        /// <returns></returns>
        public static string ComputeMd5(string str, bool isUpper = true, bool isIncludeHyphen = false,
            Encoding encoding = null, int resultLength = 32) =>
            ComputeMd5((encoding ?? Encoding).GetBytes(str), isUpper, isIncludeHyphen, resultLength);

        /// <summary>
        /// Get MD5 hash string
        /// </summary>
        /// <param name="bytes"></param>
        /// <param name="isUpper"></param>
        /// <param name="isIncludeHyphen"></param>
        /// <param name="resultLength"></param>
        /// <returns></returns>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        /// <exception cref="ArgumentException"></exception>
        /// <exception cref="ArgumentNullException"></exception>
        /// <exception cref="NotSupportedException"></exception>
        public static string ComputeMd5(byte[] bytes, bool isUpper = true, bool isIncludeHyphen = false,
            int resultLength = 32)
        {
            if (resultLength is <= 0 or > 32)
                throw new ArgumentOutOfRangeException(nameof(resultLength),
                    "Result length can only be greater than 0 and less than or equal to 32.");
            if (resultLength % 2 != 0)
                throw new ArgumentException("Result length can only be an even number.", nameof(resultLength));
            if (bytes is null)
                throw new ArgumentNullException(nameof(bytes));

            var length = resultLength / 2;
            var startIndex = (16 - length) / 2;
            using var md5 = MD5.Create();
            if (md5 is null) throw new NotSupportedException(nameof(md5));
            var hashBytes = md5.ComputeHash(bytes);
            var str = BitConverter.ToString(hashBytes, startIndex, length);
            str = isUpper ? str.ToUpper() : str.ToLower();
            str = isIncludeHyphen ? str : str.Replace("-", "");
            return str;
        }
    }
}