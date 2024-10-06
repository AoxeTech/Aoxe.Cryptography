#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_512;

public static partial class Sha3_512Helper
{
    public static byte[] ComputeHash(Stream inputStream)
    {
        using var sha3_512 = System.Security.Cryptography.SHA3_512.Create();
        return inputStream.ToHash(sha3_512);
    }

    public static string ComputeHashString(Stream inputStream)
    {
        using var sha3_512 = System.Security.Cryptography.SHA3_512.Create();
        return inputStream.ToHashString(sha3_512);
    }
}
#endif
