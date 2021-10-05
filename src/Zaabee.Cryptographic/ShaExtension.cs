using System.Text;

namespace Zaabee.Cryptographic
{
    public static class ShaExtension
    {
        public static string ToSha1(this string str, bool isUpper = true, bool isIncludeHyphen = false,
            Encoding encoding = null) =>
            ShaHelper.GetSha1Hash(str, isUpper, isIncludeHyphen, encoding);

        public static string ToSha1(this byte[] bytes, bool isUpper = true, bool isIncludeHyphen = false) =>
            ShaHelper.GetSha1Hash(bytes, isUpper, isIncludeHyphen);

        public static string ToSha256(this string str, bool isUpper = true, bool isIncludeHyphen = false,
            Encoding encoding = null) =>
            ShaHelper.GetSha256Hash(str, isUpper, isIncludeHyphen, encoding);

        public static string ToSha256(this byte[] bytes, bool isUpper = true, bool isIncludeHyphen = false) =>
            ShaHelper.GetSha256Hash(bytes, isUpper, isIncludeHyphen);

        public static string ToSha384(this string str, bool isUpper = true, bool isIncludeHyphen = false,
            Encoding encoding = null) =>
            ShaHelper.GetSha384Hash(str, isUpper, isIncludeHyphen, encoding);

        public static string ToSha384(this byte[] bytes, bool isUpper = true, bool isIncludeHyphen = false) =>
            ShaHelper.GetSha384Hash(bytes, isUpper, isIncludeHyphen);

        public static string ToSha512(this string str, bool isUpper = true, bool isIncludeHyphen = false,
            Encoding encoding = null) =>
            ShaHelper.GetSha512Hash(str, isUpper, isIncludeHyphen, encoding);

        public static string ToSha512(this byte[] bytes, bool isUpper = true, bool isIncludeHyphen = false) =>
            ShaHelper.GetSha512Hash(bytes, isUpper, isIncludeHyphen);
    }
}