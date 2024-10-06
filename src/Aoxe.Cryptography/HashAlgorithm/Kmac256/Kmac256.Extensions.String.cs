# if NET9_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Kmac256;

public static partial class Kmac256Extensions
{
    public static byte[] ToKmac256(
        this string str,
        byte[] key,
        int outputLength,
        byte[]? customizationString = default
    ) => Kmac256Helper.ComputeHash(key, str, outputLength, customizationString);

    public static string ToKmac256String(
        this string str,
        byte[] key,
        int outputLength,
        byte[]? customizationString = default
    ) => Kmac256Helper.ComputeHashString(key, str, outputLength, customizationString);

    public static void ToKmac256(
        this string str,
        ReadOnlySpan<byte> key,
        Span<byte> destination,
        ReadOnlySpan<byte> customizationString = default
    ) => Kmac256Helper.ComputeHash(key, str, destination, customizationString);
}
# endif
