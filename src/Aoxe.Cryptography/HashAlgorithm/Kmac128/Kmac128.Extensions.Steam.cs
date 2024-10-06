# if NET9_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Kmac128;

public static partial class Kmac128Extensions
{
    public static byte[] ToKmac128(
        this Stream inputStream,
        byte[] key,
        int outputLength,
        byte[]? customizationString = default
    ) => Kmac128Helper.ComputeHash(key, inputStream, outputLength, customizationString);

    public static byte[] ToKmac128(
        this Stream inputStream,
        ReadOnlySpan<byte> key,
        int outputLength,
        ReadOnlySpan<byte> customizationString = default
    ) => Kmac128Helper.ComputeHash(key, inputStream, outputLength, customizationString);

    public static string ToKmac128String(
        this Stream inputStream,
        byte[] key,
        int outputLength,
        byte[]? customizationString = default
    ) => Kmac128Helper.ComputeHashString(key, inputStream, outputLength, customizationString);

    public static string ToKmac128String(
        this Stream inputStream,
        ReadOnlySpan<byte> key,
        int outputLength,
        ReadOnlySpan<byte> customizationString = default
    ) => Kmac128Helper.ComputeHashString(key, inputStream, outputLength, customizationString);

    public static void ToKmac128(
        this Stream inputStream,
        ReadOnlySpan<byte> key,
        Span<byte> destination,
        ReadOnlySpan<byte> customizationString = default
    ) => Kmac128Helper.ComputeHash(key, inputStream, destination, customizationString);
}
# endif
