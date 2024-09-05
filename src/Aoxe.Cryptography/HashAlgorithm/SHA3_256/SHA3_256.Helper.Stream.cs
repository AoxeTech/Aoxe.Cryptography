#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_256;

public static partial class Sha3_256Helper
{
    public static byte[] ComputeHash(Stream inputStream)
    {
        using var sha3_256 = System.Security.Cryptography.SHA3_256.Create();
        return inputStream.ToHash(sha3_256);
    }

    public static string ComputeHashString(Stream inputStream)
    {
        using var sha3_256 = System.Security.Cryptography.SHA3_256.Create();
        return inputStream.ToHashString(sha3_256);
    }
}
#endif
