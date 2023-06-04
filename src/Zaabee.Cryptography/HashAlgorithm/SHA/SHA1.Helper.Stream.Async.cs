namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
#if !NETSTANDARD2_0
    public static Task<byte[]> ComputeSha1Async(Stream inputStream)
    {
        using var sha1 = SHA1.Create();
        return inputStream.ToHashAsync(sha1);
    }
#endif
}