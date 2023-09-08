namespace Zaabee.Cryptography.HashAlgorithm.SHA384;

public static partial class Sha384Extensions
{
    public static byte[] ToSha384(this byte[] bytes) =>
        Sha384Helper.ComputeHash(bytes);

    public static byte[] ToSha384(
        this byte[] bytes,
        int offset,
        int count) =>
        Sha384Helper.ComputeHash(bytes, offset, count);

    public static string ToSha384String(this byte[] bytes) =>
        Sha384Helper.ComputeHashString(bytes);

    public static string ToSha384String(
        this byte[] bytes,
        int offset,
        int count) =>
        Sha384Helper.ComputeHashString(bytes, offset, count);
}