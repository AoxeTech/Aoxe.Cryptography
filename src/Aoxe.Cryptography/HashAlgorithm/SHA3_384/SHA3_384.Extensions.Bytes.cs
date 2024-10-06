#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_384;

public static partial class Sha3_384Extensions
{
    public static byte[] ToSha3_384(this byte[] bytes) => Sha3_384Helper.ComputeHash(bytes);

    public static byte[] ToSha3_384(this byte[] bytes, int offset, int count) =>
        Sha3_384Helper.ComputeHash(bytes, offset, count);

    public static string ToSha3_384String(this byte[] bytes) =>
        Sha3_384Helper.ComputeHashString(bytes);

    public static string ToSha3_384String(this byte[] bytes, int offset, int count) =>
        Sha3_384Helper.ComputeHashString(bytes, offset, count);
}
#endif
