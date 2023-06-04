namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
    public static byte[] ComputeSha384(Stream inputStream)
    {
        using var sha384 = SHA384.Create();
        return inputStream.ToHash(sha384);
    }
}