namespace Zaabee.Cryptography.HashAlgorithm.MD5;

public static partial class Md5Helper
{
#if !NETSTANDARD2_0
    public static Task<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default)
    {
        using var md5 = System.Security.Cryptography.MD5.Create();
        return inputStream.ToHashAsync(md5, cancellationToken);
    }

    public static Task<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default)
    {
        using var md5 = System.Security.Cryptography.MD5.Create();
        return inputStream.ToHashStringAsync(md5, cancellationToken);
    }
#endif
}