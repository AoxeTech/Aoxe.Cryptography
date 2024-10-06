#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_512;

public static partial class Sha3_512Helper
{
    public static byte[] ComputeHash(string str, Encoding? encoding = null)
    {
        using var sha3_512 = System.Security.Cryptography.SHA3_512.Create();
        return str.ToHash(sha3_512, encoding);
    }

    public static string ComputeHashString(string str, Encoding? encoding = null)
    {
        using var sha3_512 = System.Security.Cryptography.SHA3_512.Create();
        return str.ToHashString(sha3_512, encoding);
    }
}
#endif
