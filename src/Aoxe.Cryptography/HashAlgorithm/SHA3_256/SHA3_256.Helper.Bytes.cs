#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_256;

public static partial class Sha3_256Helper
{
    public static byte[] ComputeHash(byte[] bytes)
    {
        using var sha3_256 = System.Security.Cryptography.SHA3_256.Create();
        return bytes.ToHash(sha3_256);
    }

    public static byte[] ComputeHash(byte[] bytes, int offset, int count)
    {
        using var sha3_256 = System.Security.Cryptography.SHA3_256.Create();
        return bytes.ToHash(sha3_256, offset, count);
    }

    public static string ComputeHashString(byte[] bytes)
    {
        using var sha3_256 = System.Security.Cryptography.SHA3_256.Create();
        return bytes.ToHashString(sha3_256);
    }

    public static string ComputeHashString(byte[] bytes, int offset, int count)
    {
        using var sha3_256 = System.Security.Cryptography.SHA3_256.Create();
        return bytes.ToHashString(sha3_256, offset, count);
    }
}
#endif
