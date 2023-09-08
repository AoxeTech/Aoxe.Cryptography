namespace Zaabee.Cryptography.HashAlgorithm.SHA1;

public static partial class Sha1Extensions
{
    public static byte[] ToSha1(this byte[] bytes) =>
        Sha1Helper.ComputeHash(bytes);

    public static byte[] ToSha1(
        this byte[] bytes,
        int offset,
        int count) =>
        Sha1Helper.ComputeHash(bytes, offset, count);

    public static string ToSha1String(this byte[] bytes) =>
        Sha1Helper.ComputeHashString(bytes);

    public static string ToSha1String(
        this byte[] bytes,
        int offset,
        int count) =>
        Sha1Helper.ComputeHashString(bytes, offset, count);
}