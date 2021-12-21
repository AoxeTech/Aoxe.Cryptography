namespace Zaabee.Cryptographic;

public static class Md5Extensions
{
    public static string ToMd5String(this string str, Encoding encoding = null) =>
        Md5Helper.GetMd5HashString(str, encoding);

    public static byte[] ToMd5Bytes(this string str, Encoding encoding = null) =>
        Md5Helper.GetMd5HashBytes(str, encoding);

    public static string ToMd5String(this byte[] bytes) =>
        Md5Helper.GetMd5HashString(bytes);

    public static byte[] ToMd5Bytes(this byte[] bytes) =>
        Md5Helper.GetMd5HashBytes(bytes);
}