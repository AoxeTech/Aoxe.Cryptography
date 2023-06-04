namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
#if !NETSTANDARD2_0
    public static Task<byte[]> ComputeSha384Async(Stream inputStream)
    {
        using var sha384 = SHA384.Create();
        return inputStream.ToHashAsync(sha384);
    }
#endif
}