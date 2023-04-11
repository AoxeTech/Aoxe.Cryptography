namespace Zaabee.Cryptography.HashAlgorithm.MD5;

public static partial class Md5Extensions
{
    public static byte[] ToMd5(this byte[] bytes) =>
        HashAlgorithm.MD5.Md5Helper.ComputeMd5(bytes);

    public static byte[] ToMd5(
        this byte[] bytes,
        int offset,
        int count) =>
        HashAlgorithm.MD5.Md5Helper.ComputeMd5(bytes, offset, count);
}