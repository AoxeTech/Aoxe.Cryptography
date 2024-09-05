#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_256;

public static partial class Sha3_256Helper
{
    public static byte[] ComputeHash(string str, Encoding? encoding = null)
    {
        using var sha3_256 = System.Security.Cryptography.SHA3_256.Create();
        return str.ToHash(sha3_256, encoding);
    }

    public static string ComputeHashString(string str, Encoding? encoding = null)
    {
        using var sha3_256 = System.Security.Cryptography.SHA3_256.Create();
        return str.ToHashString(sha3_256, encoding);
    }
}
#endif
