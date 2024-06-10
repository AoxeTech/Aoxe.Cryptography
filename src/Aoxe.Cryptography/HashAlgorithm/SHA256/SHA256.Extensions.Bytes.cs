namespace Aoxe.Cryptography.HashAlgorithm.SHA256;

public static partial class Sha256Extensions
{
    public static byte[] ToSha256(this byte[] bytes) => Sha256Helper.ComputeHash(bytes);

    public static byte[] ToSha256(this byte[] bytes, int offset, int count) =>
        Sha256Helper.ComputeHash(bytes, offset, count);

    public static string ToSha256String(this byte[] bytes) => Sha256Helper.ComputeHashString(bytes);

    public static string ToSha256String(this byte[] bytes, int offset, int count) =>
        Sha256Helper.ComputeHashString(bytes, offset, count);
}
