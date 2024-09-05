#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_256;

public static partial class Sha3_256Extensions
{
    public static byte[] ToSha3_256(this Stream inputStream) =>
        Sha3_256Helper.ComputeHash(inputStream);

    public static string ToSha3_256String(this Stream inputStream) =>
        Sha3_256Helper.ComputeHashString(inputStream);
}
#endif
