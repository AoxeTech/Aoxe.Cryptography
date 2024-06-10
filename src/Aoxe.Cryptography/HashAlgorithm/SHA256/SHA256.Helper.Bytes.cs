namespace Aoxe.Cryptography.HashAlgorithm.SHA256;

public static partial class Sha256Helper
{
    public static byte[] ComputeHash(byte[] bytes)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        return bytes.ToHash(sha256);
    }

    public static byte[] ComputeHash(byte[] bytes, int offset, int count)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        return bytes.ToHash(sha256, offset, count);
    }

    public static string ComputeHashString(byte[] bytes)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        return bytes.ToHashString(sha256);
    }

    public static string ComputeHashString(byte[] bytes, int offset, int count)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        return bytes.ToHashString(sha256, offset, count);
    }
}
