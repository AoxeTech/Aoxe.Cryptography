namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
#if !NETSTANDARD2_0
    public static Task<byte[]> ComputeSha512Async(Stream inputStream)
    {
        using var sha512 = SHA512.Create();
        return inputStream.ToHashAsync(sha512);
    }
#endif
}