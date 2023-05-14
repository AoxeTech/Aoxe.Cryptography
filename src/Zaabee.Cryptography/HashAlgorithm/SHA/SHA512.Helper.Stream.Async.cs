namespace Zaabee.Cryptography.HashAlgorithm.SHA;

public static partial class ShaHelper
{
#if !NETSTANDARD2_0
    public static Task<byte[]> ComputeSha512Async(Stream inputStream)
    {
        using var sha512 = System.Security.Cryptography.SHA512.Create();
        return sha512.ToHashAsync(inputStream);
    }
#endif
}