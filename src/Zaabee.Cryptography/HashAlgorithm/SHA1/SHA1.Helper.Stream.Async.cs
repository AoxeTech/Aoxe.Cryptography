namespace Zaabee.Cryptography.HashAlgorithm.SHA1;

public static partial class Sha1Helper
{
#if !NETSTANDARD2_0
    public static ValueTask<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    )
    {
        using var sha1 = System.Security.Cryptography.SHA1.Create();
        return inputStream.ToHashAsync(sha1, cancellationToken: cancellationToken);
    }

    public static ValueTask<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    )
    {
        using var sha1 = System.Security.Cryptography.SHA1.Create();
        return inputStream.ToHashStringAsync(sha1, cancellationToken: cancellationToken);
    }
#endif
}
