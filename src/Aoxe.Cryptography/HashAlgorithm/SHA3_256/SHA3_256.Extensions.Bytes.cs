#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_256;

public static partial class Sha3_256Extensions
{
    public static byte[] ToSha3_256(this byte[] bytes) => Sha3_256Helper.ComputeHash(bytes);

    public static byte[] ToSha3_256(this byte[] bytes, int offset, int count) =>
        Sha3_256Helper.ComputeHash(bytes, offset, count);

    public static string ToSha3_256String(this byte[] bytes) =>
        Sha3_256Helper.ComputeHashString(bytes);

    public static string ToSha3_256String(this byte[] bytes, int offset, int count) =>
        Sha3_256Helper.ComputeHashString(bytes, offset, count);
}
#endif
