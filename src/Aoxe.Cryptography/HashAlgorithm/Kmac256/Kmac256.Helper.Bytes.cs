# if NET9_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Kmac256;

public static partial class Kmac256Helper
{
    public static byte[] ComputeHash(
        byte[] key,
        byte[] source,
        int outputLength,
        byte[]? customizationString = default
    ) =>
        System
            .Security
            .Cryptography
            .Kmac256
            .HashData(key, source, outputLength, customizationString);

    public static string ComputeHashString(
        byte[] key,
        byte[] source,
        int outputLength,
        byte[]? customizationString = default
    ) => ComputeHash(key, source, outputLength, customizationString).ToHexString();
}
#endif
