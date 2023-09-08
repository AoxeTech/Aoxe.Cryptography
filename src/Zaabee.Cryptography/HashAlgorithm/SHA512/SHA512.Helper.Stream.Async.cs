namespace Zaabee.Cryptography.HashAlgorithm.SHA512;

public static partial class Sha512Helper
{
#if !NETSTANDARD2_0
    public static Task<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default)
    {
        using var sha512 = System.Security.Cryptography.SHA512.Create();
        return inputStream.ToHashAsync(sha512, cancellationToken: cancellationToken);
    }

    public static Task<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default)
    {
        using var sha512 = System.Security.Cryptography.SHA512.Create();
        return inputStream.ToHashStringAsync(sha512, cancellationToken: cancellationToken);
    }
#endif
}