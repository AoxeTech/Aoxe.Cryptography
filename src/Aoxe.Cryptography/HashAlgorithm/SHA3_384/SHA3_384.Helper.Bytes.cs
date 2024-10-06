#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_384;

public static partial class Sha3_384Helper
{
    public static byte[] ComputeHash(byte[] bytes)
    {
        using var sha3_384 = System.Security.Cryptography.SHA3_384.Create();
        return bytes.ToHash(sha3_384);
    }

    public static byte[] ComputeHash(byte[] bytes, int offset, int count)
    {
        using var sha3_384 = System.Security.Cryptography.SHA3_384.Create();
        return bytes.ToHash(sha3_384, offset, count);
    }

    public static string ComputeHashString(byte[] bytes)
    {
        using var sha3_384 = System.Security.Cryptography.SHA3_384.Create();
        return bytes.ToHashString(sha3_384);
    }

    public static string ComputeHashString(byte[] bytes, int offset, int count)
    {
        using var sha3_384 = System.Security.Cryptography.SHA3_384.Create();
        return bytes.ToHashString(sha3_384, offset, count);
    }
}
#endif
