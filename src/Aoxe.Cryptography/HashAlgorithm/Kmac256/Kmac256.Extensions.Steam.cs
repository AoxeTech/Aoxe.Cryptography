# if NET9_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Kmac256;

public static partial class Kmac256Extensions
{
    public static byte[] ToKmac256(
        this Stream inputStream,
        byte[] key,
        int outputLength,
        byte[]? customizationString = default
    ) => Kmac256Helper.ComputeHash(key, inputStream, outputLength, customizationString);

    public static byte[] ToKmac256(
        this Stream inputStream,
        ReadOnlySpan<byte> key,
        int outputLength,
        ReadOnlySpan<byte> customizationString = default
    ) => Kmac256Helper.ComputeHash(key, inputStream, outputLength, customizationString);

    public static string ToKmac256String(
        this Stream inputStream,
        byte[] key,
        int outputLength,
        byte[]? customizationString = default
    ) => Kmac256Helper.ComputeHashString(key, inputStream, outputLength, customizationString);

    public static string ToKmac256String(
        this Stream inputStream,
        ReadOnlySpan<byte> key,
        int outputLength,
        ReadOnlySpan<byte> customizationString = default
    ) => Kmac256Helper.ComputeHashString(key, inputStream, outputLength, customizationString);

    public static void ToKmac256(
        this Stream inputStream,
        ReadOnlySpan<byte> key,
        Span<byte> destination,
        ReadOnlySpan<byte> customizationString = default
    ) => Kmac256Helper.ComputeHash(key, inputStream, destination, customizationString);
}
# endif
