namespace Zaabee.Cryptography.HashAlgorithm.MD5;

public static partial class Md5Extensions
{
    public static byte[] ToMd5(this byte[] bytes) =>
        Md5Helper.ComputeMd5(bytes);

    public static byte[] ToMd5(
        this byte[] bytes,
        int offset,
        int count) =>
        Md5Helper.ComputeMd5(bytes, offset, count);
}