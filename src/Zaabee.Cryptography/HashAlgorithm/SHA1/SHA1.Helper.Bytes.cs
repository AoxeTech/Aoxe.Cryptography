namespace Zaabee.Cryptography.HashAlgorithm.SHA1;

public static partial class Sha1Helper
{
    public static byte[] ComputeHash(byte[] bytes)
    {
        using var sha1 = System.Security.Cryptography.SHA1.Create();
        return bytes.ToHash(sha1);
    }

    public static byte[] ComputeHash(
        byte[] bytes,
        int offset,
        int count)
    {
        using var sha1 = System.Security.Cryptography.SHA1.Create();
        return bytes.ToHash(sha1, offset, count);
    }

    public static string ComputeHashString(byte[] bytes)
    {
        using var sha1 = System.Security.Cryptography.SHA1.Create();
        return bytes.ToHashString(sha1);
    }

    public static string ComputeHashString(
        byte[] bytes,
        int offset,
        int count)
    {
        using var sha1 = System.Security.Cryptography.SHA1.Create();
        return bytes.ToHashString(sha1, offset, count);
    }
}