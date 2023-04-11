namespace Zaabee.Cryptography.SHA;

public static partial class ShaHelper
{
#if !NETSTANDARD2_0
    public static Task<byte[]> ComputeSha256Async(Stream inputStream)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        return sha256.ToHashAsync(inputStream);
    }
#endif
}