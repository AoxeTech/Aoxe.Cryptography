namespace Zaabee.Cryptography.HashAlgorithm.SHA512;

public static partial class Sha512Helper
{
    public static byte[] ComputeHash(Stream inputStream)
    {
        using var sha512 = System.Security.Cryptography.SHA512.Create();
        return inputStream.ToHash(sha512);
    }

    public static string ComputeHashString(Stream inputStream)
    {
        using var sha512 = System.Security.Cryptography.SHA512.Create();
        return inputStream.ToHashString(sha512);
    }
}