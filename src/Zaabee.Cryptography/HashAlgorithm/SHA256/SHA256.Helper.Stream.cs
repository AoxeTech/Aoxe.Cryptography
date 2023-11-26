namespace Zaabee.Cryptography.HashAlgorithm.SHA256;

public static partial class Sha256Helper
{
    public static byte[] ComputeHash(Stream inputStream)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        return inputStream.ToHash(sha256);
    }

    public static string ComputeHashString(Stream inputStream)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        return inputStream.ToHashString(sha256);
    }
}
