namespace Zaabee.Cryptography.HashAlgorithm.MD5;

public static partial class Md5Helper
{
#if !NETSTANDARD2_0
    public static Task<byte[]> ComputeMd5Async(Stream inputStream)
    {
        using var md5 = System.Security.Cryptography.MD5.Create();
        return inputStream.ToHashAsync(md5);
    }
#endif
}