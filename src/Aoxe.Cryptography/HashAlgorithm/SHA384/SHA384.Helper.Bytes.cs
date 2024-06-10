namespace Aoxe.Cryptography.HashAlgorithm.SHA384;

public static partial class Sha384Helper
{
    public static byte[] ComputeHash(byte[] bytes)
    {
        using var sha384 = System.Security.Cryptography.SHA384.Create();
        return bytes.ToHash(sha384);
    }

    public static byte[] ComputeHash(byte[] bytes, int offset, int count)
    {
        using var sha384 = System.Security.Cryptography.SHA384.Create();
        return bytes.ToHash(sha384, offset, count);
    }

    public static string ComputeHashString(byte[] bytes)
    {
        using var sha384 = System.Security.Cryptography.SHA384.Create();
        return bytes.ToHashString(sha384);
    }

    public static string ComputeHashString(byte[] bytes, int offset, int count)
    {
        using var sha384 = System.Security.Cryptography.SHA384.Create();
        return bytes.ToHashString(sha384, offset, count);
    }
}
