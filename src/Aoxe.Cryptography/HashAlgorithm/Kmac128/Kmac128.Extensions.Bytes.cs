# if NET9_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Kmac128;

public static partial class Kmac128Extensions
{
    public static byte[] ToKmac128(
        this byte[] bytes,
        byte[] key,
        int outputLength,
        byte[]? customizationString = default
    ) => Kmac128Helper.ComputeHash(key, bytes, outputLength, customizationString);

    public static string ToKmac128String(
        this byte[] bytes,
        byte[] key,
        int outputLength,
        byte[]? customizationString = default
    ) => Kmac128Helper.ComputeHashString(key, bytes, outputLength, customizationString);
}
# endif
