using System.Text;

namespace Zaabee.Cryptographic
{
    public static class ShaExtension
    {
        public static string ToSha1(this string str, bool isUpper = true, bool isIncludeHyphen = false,
            Encoding encoding = null) =>
            ShaHelper.ComputeSha1(str, isUpper, isIncludeHyphen, encoding);

        public static string ToSha1(this byte[] bytes, bool isUpper = true, bool isIncludeHyphen = false) =>
            ShaHelper.ComputeSha1(bytes, isUpper, isIncludeHyphen);

        public static string ToSha256(this string str, bool isUpper = true, bool isIncludeHyphen = false,
            Encoding encoding = null) =>
            ShaHelper.ComputeSha256(str, isUpper, isIncludeHyphen, encoding);

        public static string ToSha256(this byte[] bytes, bool isUpper = true, bool isIncludeHyphen = false) =>
            ShaHelper.ComputeSha256(bytes, isUpper, isIncludeHyphen);

        public static string ToSha384(this string str, bool isUpper = true, bool isIncludeHyphen = false,
            Encoding encoding = null) =>
            ShaHelper.ComputeSha384(str, isUpper, isIncludeHyphen, encoding);

        public static string ToSha384(this byte[] bytes, bool isUpper = true, bool isIncludeHyphen = false) =>
            ShaHelper.ComputeSha384(bytes, isUpper, isIncludeHyphen);

        public static string ToSha512(this string str, bool isUpper = true, bool isIncludeHyphen = false,
            Encoding encoding = null) =>
            ShaHelper.ComputeSha512(str, isUpper, isIncludeHyphen, encoding);

        public static string ToSha512(this byte[] bytes, bool isUpper = true, bool isIncludeHyphen = false) =>
            ShaHelper.ComputeSha512(bytes, isUpper, isIncludeHyphen);
    }
}