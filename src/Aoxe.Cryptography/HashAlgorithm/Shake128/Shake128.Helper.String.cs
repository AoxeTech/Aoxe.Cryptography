# if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Shake128;

public static partial class Shake128Helper
{
    public static byte[] ComputeHash(string source, int outputLength) =>
        System.Security.Cryptography.Shake128.HashData(source.GetUtf8Bytes(), outputLength);

    public static string ComputeHashString(string source, int outputLength) =>
        ComputeHash(source, outputLength).ToHexString();

    public static void ComputeHash(string source, Span<byte> destination) =>
        System.Security.Cryptography.Shake128.HashData(source.GetUtf8Bytes(), destination);
}
# endif
