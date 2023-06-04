namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
#if !NETSTANDARD2_0
    public static Task<byte[]> ComputeSha256Async(Stream inputStream)
    {
        using var sha256 = SHA256.Create();
        return inputStream.ToHashAsync(sha256);
    }
#endif
}