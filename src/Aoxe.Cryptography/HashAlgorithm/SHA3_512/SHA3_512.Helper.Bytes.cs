#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_512;

public static partial class Sha3_512Helper
{
    public static byte[] ComputeHash(byte[] bytes)
    {
        using var sha3_512 = System.Security.Cryptography.SHA3_512.Create();
        return bytes.ToHash(sha3_512);
    }

    public static byte[] ComputeHash(byte[] bytes, int offset, int count)
    {
        using var sha3_512 = System.Security.Cryptography.SHA3_512.Create();
        return bytes.ToHash(sha3_512, offset, count);
    }

    public static string ComputeHashString(byte[] bytes)
    {
        using var sha3_512 = System.Security.Cryptography.SHA3_512.Create();
        return bytes.ToHashString(sha3_512);
    }

    public static string ComputeHashString(byte[] bytes, int offset, int count)
    {
        using var sha3_512 = System.Security.Cryptography.SHA3_512.Create();
        return bytes.ToHashString(sha3_512, offset, count);
    }
}
#endif
