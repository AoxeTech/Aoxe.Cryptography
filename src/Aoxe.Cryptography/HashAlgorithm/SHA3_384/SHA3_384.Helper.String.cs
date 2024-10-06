#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_384;

public static partial class Sha3_384Helper
{
    public static byte[] ComputeHash(string str, Encoding? encoding = null)
    {
        using var sha3_384 = System.Security.Cryptography.SHA3_384.Create();
        return str.ToHash(sha3_384, encoding);
    }

    public static string ComputeHashString(string str, Encoding? encoding = null)
    {
        using var sha3_384 = System.Security.Cryptography.SHA3_384.Create();
        return str.ToHashString(sha3_384, encoding);
    }
}
#endif
