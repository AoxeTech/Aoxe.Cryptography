# if NET9_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Kmac256;

public static partial class Kmac256Helper
{
    public static byte[] ComputeHash(
        byte[] key,
        Stream source,
        int outputLength,
        byte[]? customizationString = default
    ) =>
        System
            .Security
            .Cryptography
            .Kmac256
            .HashData(key, source, outputLength, customizationString);

    public static byte[] ComputeHash(
        ReadOnlySpan<byte> key,
        Stream source,
        int outputLength,
        ReadOnlySpan<byte> customizationString = default
    ) =>
        System
            .Security
            .Cryptography
            .Kmac256
            .HashData(key, source, outputLength, customizationString);

    public static string ComputeHashString(
        byte[] key,
        Stream source,
        int outputLength,
        byte[]? customizationString = default
    ) => ComputeHash(key, source, outputLength, customizationString).ToHexString();

    public static string ComputeHashString(
        ReadOnlySpan<byte> key,
        Stream source,
        int outputLength,
        ReadOnlySpan<byte> customizationString = default
    ) => ComputeHash(key, source, outputLength, customizationString).ToHexString();

    public static void ComputeHash(
        ReadOnlySpan<byte> key,
        Stream source,
        Span<byte> destination,
        ReadOnlySpan<byte> customizationString = default
    ) =>
        System
            .Security
            .Cryptography
            .Kmac256
            .HashData(key, source, destination, customizationString);
}
#endif
