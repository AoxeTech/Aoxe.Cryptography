# if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Shake256;

public static partial class Shake256Helper
{
    public static byte[] ComputeHash(byte[] source, int outputLength) =>
        System.Security.Cryptography.Shake256.HashData(source, outputLength);

    public static string ComputeHashString(byte[] source, int outputLength) =>
        ComputeHash(source, outputLength).ToHexString();
}
#endif
