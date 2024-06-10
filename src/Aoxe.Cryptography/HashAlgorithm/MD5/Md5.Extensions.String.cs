namespace Aoxe.Cryptography.HashAlgorithm.MD5;

public static partial class Md5Extensions
{
    public static byte[] ToMd5(this string str, Encoding? encoding = null) =>
        Md5Helper.ComputeHash(str, encoding);

    public static string ToMd5String(this string str, Encoding? encoding = null) =>
        Md5Helper.ComputeHashString(str, encoding);
}
