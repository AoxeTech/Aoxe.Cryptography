# if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Shake256;

public static partial class Shake256Helper
{
    public static byte[] ComputeHash(Stream source, int outputLength) =>
        System.Security.Cryptography.Shake256.HashData(source, outputLength);

    public static string ComputeHashString(Stream source, int outputLength) =>
        ComputeHash(source, outputLength).ToHexString();

    public static void ComputeHash(Stream source, Span<byte> destination) =>
        System.Security.Cryptography.Shake256.HashData(source, destination);
}
#endif
