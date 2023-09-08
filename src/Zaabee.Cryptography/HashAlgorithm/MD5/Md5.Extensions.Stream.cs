namespace Zaabee.Cryptography.HashAlgorithm.MD5;

public static partial class Md5Extensions
{
    public static byte[] ToMd5(this Stream inputStream) =>
        Md5Helper.ComputeHash(inputStream);

    public static string ToMd5String(this Stream inputStream) =>
        Md5Helper.ComputeHashString(inputStream);
}