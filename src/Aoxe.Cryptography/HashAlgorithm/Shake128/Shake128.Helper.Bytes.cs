# if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Shake128;

public static partial class Shake128Helper
{
    public static byte[] ComputeHash(byte[] source, int outputLength) =>
        System.Security.Cryptography.Shake128.HashData(source, outputLength);

    public static string ComputeHashString(byte[] source, int outputLength) =>
        ComputeHash(source, outputLength).ToHexString();
}
#endif
