namespace Zaabee.Cryptography.HashAlgorithm.SHA512;

public static partial class Sha512Helper
{
    public static byte[] ComputeHash(byte[] bytes)
    {
        using var sha512 = System.Security.Cryptography.SHA512.Create();
        return bytes.ToHash(sha512);
    }

    public static byte[] ComputeHash(
        byte[] bytes,
        int offset,
        int count)
    {
        using var sha512 = System.Security.Cryptography.SHA512.Create();
        return bytes.ToHash(sha512, offset, count);
    }

    public static string ComputeHashString(byte[] bytes)
    {
        using var sha512 = System.Security.Cryptography.SHA512.Create();
        return bytes.ToHashString(sha512);
    }

    public static string ComputeHashString(
        byte[] bytes,
        int offset,
        int count)
    {
        using var sha512 = System.Security.Cryptography.SHA512.Create();
        return bytes.ToHashString(sha512, offset, count);
    }
}