# if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Shake128;

public static partial class Shake128Helper
{
    public static byte[] ComputeHash(Stream source, int outputLength) =>
        System.Security.Cryptography.Shake128.HashData(source, outputLength);

    public static string ComputeHashString(Stream source, int outputLength) =>
        ComputeHash(source, outputLength).ToHexString();

    public static void ComputeHash(Stream source, Span<byte> destination) =>
        System.Security.Cryptography.Shake128.HashData(source, destination);
}
#endif
