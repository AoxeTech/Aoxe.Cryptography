# if NET9_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Kmac256;

public static partial class Kmac256Extensions
{
    public static byte[] ToKmac256(
        this byte[] bytes,
        byte[] key,
        int outputLength,
        byte[]? customizationString = default
    ) => Kmac256Helper.ComputeHash(key, bytes, outputLength, customizationString);

    public static string ToKmac256String(
        this byte[] bytes,
        byte[] key,
        int outputLength,
        byte[]? customizationString = default
    ) => Kmac256Helper.ComputeHashString(key, bytes, outputLength, customizationString);
}
# endif
