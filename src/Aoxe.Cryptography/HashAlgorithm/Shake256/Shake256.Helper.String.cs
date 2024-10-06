# if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Shake256;

public static partial class Shake256Helper
{
    public static byte[] ComputeHash(string source, int outputLength) =>
        System.Security.Cryptography.Shake256.HashData(source.GetUtf8Bytes(), outputLength);

    public static string ComputeHashString(string source, int outputLength) =>
        ComputeHash(source, outputLength).ToHexString();

    public static void ComputeHash(string source, Span<byte> destination) =>
        System.Security.Cryptography.Shake256.HashData(source.GetUtf8Bytes(), destination);
}
# endif
