# if NET9_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Kmac128;

public static partial class Kmac128Extensions
{
    public static byte[] ToKmac128(
        this string str,
        byte[] key,
        int outputLength,
        byte[]? customizationString = default
    ) => Kmac128Helper.ComputeHash(key, str, outputLength, customizationString);

    public static string ToKmac128String(
        this string str,
        byte[] key,
        int outputLength,
        byte[]? customizationString = default
    ) => Kmac128Helper.ComputeHashString(key, str, outputLength, customizationString);

    public static void ToKmac128(
        this string str,
        ReadOnlySpan<byte> key,
        Span<byte> destination,
        ReadOnlySpan<byte> customizationString = default
    ) => Kmac128Helper.ComputeHash(key, str, destination, customizationString);
}
# endif
