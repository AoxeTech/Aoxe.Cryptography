#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_384;

public static partial class Sha3_384Extensions
{
    public static byte[] ToSha3_384(this Stream inputStream) =>
        Sha3_384Helper.ComputeHash(inputStream);

    public static string ToSha3_384String(this Stream inputStream) =>
        Sha3_384Helper.ComputeHashString(inputStream);
}
#endif
