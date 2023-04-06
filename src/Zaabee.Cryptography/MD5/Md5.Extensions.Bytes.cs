namespace Zaabee.Cryptography.MD5;

public static partial class Md5Extensions
{
    public static string ToMd5String(
        this string str,
        Encoding? encoding = null) =>
        Md5Helper.GetMd5String(str, encoding);

    public static byte[] ToMd5Bytes(
        this string str,
        Encoding? encoding = null) =>
        Md5Helper.GetMd5Bytes(str, encoding);
}