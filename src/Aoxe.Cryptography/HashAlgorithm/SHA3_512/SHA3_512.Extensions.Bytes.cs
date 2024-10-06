#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_512;

public static partial class Sha3_512Extensions
{
    public static byte[] ToSha3_512(this byte[] bytes) => Sha3_512Helper.ComputeHash(bytes);

    public static byte[] ToSha3_512(this byte[] bytes, int offset, int count) =>
        Sha3_512Helper.ComputeHash(bytes, offset, count);

    public static string ToSha3_512String(this byte[] bytes) =>
        Sha3_512Helper.ComputeHashString(bytes);

    public static string ToSha3_512String(this byte[] bytes, int offset, int count) =>
        Sha3_512Helper.ComputeHashString(bytes, offset, count);
}
#endif
