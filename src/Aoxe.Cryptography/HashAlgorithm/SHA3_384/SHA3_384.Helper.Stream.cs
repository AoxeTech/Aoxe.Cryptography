#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_384;

public static partial class Sha3_384Helper
{
    public static byte[] ComputeHash(Stream inputStream)
    {
        using var sha3_384 = System.Security.Cryptography.SHA3_384.Create();
        return inputStream.ToHash(sha3_384);
    }

    public static string ComputeHashString(Stream inputStream)
    {
        using var sha3_384 = System.Security.Cryptography.SHA3_384.Create();
        return inputStream.ToHashString(sha3_384);
    }
}
#endif
