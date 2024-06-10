namespace Aoxe.Cryptography.HashAlgorithm.SHA1;

public static partial class Sha1Helper
{
    public static byte[] ComputeHash(Stream inputStream)
    {
        using var sha1 = System.Security.Cryptography.SHA1.Create();
        return inputStream.ToHash(sha1);
    }

    public static string ComputeHashString(Stream inputStream)
    {
        using var sha1 = System.Security.Cryptography.SHA1.Create();
        return inputStream.ToHashString(sha1);
    }
}
