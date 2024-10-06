# if NET9_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Kmac128;

public static partial class Kmac128Extensions
{
    public static byte[] ToKmac128(
        this ReadOnlySpan<byte> bytes,
        ReadOnlySpan<byte> key,
        int outputLength,
        ReadOnlySpan<byte> customizationString = default
    ) => Kmac128Helper.ComputeHash(key, bytes, outputLength, customizationString);

    public static string ToKmac128String(
        this ReadOnlySpan<byte> bytes,
        ReadOnlySpan<byte> key,
        int outputLength,
        ReadOnlySpan<byte> customizationString = default
    ) => Kmac128Helper.ComputeHashString(key, bytes, outputLength, customizationString);

    public static void ToKmac128(
        this ReadOnlySpan<byte> bytes,
        ReadOnlySpan<byte> key,
        Span<byte> destination,
        ReadOnlySpan<byte> customizationString = default
    ) => Kmac128Helper.ComputeHash(key, bytes, destination, customizationString);
}
# endif
