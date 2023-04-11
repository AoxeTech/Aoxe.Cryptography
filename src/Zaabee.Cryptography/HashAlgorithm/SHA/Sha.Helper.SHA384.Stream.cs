namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
    public static byte[] ComputeSha384(Stream inputStream)
    {
        using var sha384 = System.Security.Cryptography.SHA384.Create();
        return sha384.ToHash(inputStream);
    }
}