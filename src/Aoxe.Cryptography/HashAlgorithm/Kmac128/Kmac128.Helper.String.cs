# if NET9_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Kmac128;

public static partial class Kmac128Helper
{
    public static byte[] ComputeHash(
        byte[] key,
        string source,
        int outputLength,
        byte[]? customizationString = default
    ) =>
        System
            .Security
            .Cryptography
            .Kmac128
            .HashData(key, source.GetUtf8Bytes(), outputLength, customizationString);

    public static string ComputeHashString(
        byte[] key,
        string source,
        int outputLength,
        byte[]? customizationString = default
    ) => ComputeHash(key, source, outputLength, customizationString).ToHexString();

    public static void ComputeHash(
        ReadOnlySpan<byte> key,
        string source,
        Span<byte> destination,
        ReadOnlySpan<byte> customizationString = default
    ) =>
        System
            .Security
            .Cryptography
            .Kmac128
            .HashData(key, source.GetUtf8Bytes(), destination, customizationString);
}
# endif
