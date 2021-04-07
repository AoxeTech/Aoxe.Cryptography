using System.Text;

namespace Zaabee.Cryptographic
{
    public static class Md5Extension
    {
        public static string ToMd5(this string str, bool isUpper = true, bool isIncludeHyphen = false,
            Encoding encoding = null, int resultLength = 32) =>
            Md5Helper.ComputeMd5(str, isUpper, isIncludeHyphen, encoding, resultLength);

        public static string ToMd5(this byte[] bytes, bool isUpper = true, bool isIncludeHyphen = false,
            int resultLength = 32) =>
            Md5Helper.ComputeMd5(bytes, isUpper, isIncludeHyphen, resultLength);
    }
}