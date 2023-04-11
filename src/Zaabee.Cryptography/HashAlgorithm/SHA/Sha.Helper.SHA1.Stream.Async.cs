namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
#if !NETSTANDARD2_0
    public static Task<byte[]> ComputeSha1Async(Stream inputStream)
    {
        using var sha1 = System.Security.Cryptography.SHA1.Create();
        return sha1.ToHashAsync(inputStream);
    }
#endif
}