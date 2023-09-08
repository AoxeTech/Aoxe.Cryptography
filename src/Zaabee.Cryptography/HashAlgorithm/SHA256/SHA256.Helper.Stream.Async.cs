namespace Zaabee.Cryptography.HashAlgorithm.SHA256;

public static partial class Sha256Helper
{
#if !NETSTANDARD2_0
    public static Task<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        return inputStream.ToHashAsync(sha256, cancellationToken: cancellationToken);
    }

    public static Task<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default)
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        return inputStream.ToHashStringAsync(sha256, cancellationToken: cancellationToken);
    }
#endif
}