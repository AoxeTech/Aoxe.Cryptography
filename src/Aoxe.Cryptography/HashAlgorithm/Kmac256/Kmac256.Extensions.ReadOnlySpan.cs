# if NET9_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Kmac256;

public static partial class Kmac256Extensions
{
    public static byte[] ToKmac256(
        this ReadOnlySpan<byte> bytes,
        ReadOnlySpan<byte> key,
        int outputLength,
        ReadOnlySpan<byte> customizationString = default
    ) => Kmac256Helper.ComputeHash(key, bytes, outputLength, customizationString);

    public static string ToKmac256String(
        this ReadOnlySpan<byte> bytes,
        ReadOnlySpan<byte> key,
        int outputLength,
        ReadOnlySpan<byte> customizationString = default
    ) => Kmac256Helper.ComputeHashString(key, bytes, outputLength, customizationString);

    public static void ToKmac256(
        this ReadOnlySpan<byte> bytes,
        ReadOnlySpan<byte> key,
        Span<byte> destination,
        ReadOnlySpan<byte> customizationString = default
    ) => Kmac256Helper.ComputeHash(key, bytes, destination, customizationString);
}
# endif
