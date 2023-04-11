namespace Zaabee.Cryptography.MD5;

public static partial class Md5Extensions
{
    public static string ToMd5(
        this string str,
        Encoding? encoding = null) =>
        Md5Helper.ComputeMd5(str, encoding);
}