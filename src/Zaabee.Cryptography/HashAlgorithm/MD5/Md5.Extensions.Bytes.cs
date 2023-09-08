namespace Zaabee.Cryptography.HashAlgorithm.MD5;

public static partial class Md5Extensions
{
    public static byte[] ToMd5(this byte[] bytes) =>
        Md5Helper.ComputeHash(bytes);

    public static byte[] ToMd5(
        this byte[] bytes,
        int offset,
        int count) =>
        Md5Helper.ComputeHash(bytes, offset, count);

    public static string ToMd5String(this byte[] bytes) =>
        Md5Helper.ComputeHashString(bytes);

    public static string ToMd5String(
        this byte[] bytes,
        int offset,
        int count) =>
        Md5Helper.ComputeHashString(bytes, offset, count);
}