using System.Text;

namespace Zaabee.Cryptographic
{
    public static class Md5Extensions
    {
        public static string ToMd5(this string str, bool isUpper = true, bool isIncludeHyphen = false,
            Encoding encoding = null, int resultLength = 32) =>
            Md5Helper.GetMd5Hash(str, isUpper, isIncludeHyphen, encoding, resultLength);

        public static string ToMd5(this byte[] bytes, bool isUpper = true, bool isIncludeHyphen = false,
            int resultLength = 32) =>
            Md5Helper.GetMd5Hash(bytes, isUpper, isIncludeHyphen, resultLength);
    }
}