namespace Aoxe.Cryptography.HashAlgorithm.SHA512;

public static partial class Sha512Extensions
{
    public static byte[] ToSha512(this byte[] bytes) => Sha512Helper.ComputeHash(bytes);

    public static byte[] ToSha512(this byte[] bytes, int offset, int count) =>
        Sha512Helper.ComputeHash(bytes, offset, count);

    public static string ToSha512String(this byte[] bytes) => Sha512Helper.ComputeHashString(bytes);

    public static string ToSha512String(this byte[] bytes, int offset, int count) =>
        Sha512Helper.ComputeHashString(bytes, offset, count);
}
