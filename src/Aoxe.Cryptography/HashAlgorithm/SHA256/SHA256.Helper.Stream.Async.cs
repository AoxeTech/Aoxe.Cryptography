namespace Aoxe.Cryptography.HashAlgorithm.SHA256;

public static partial class Sha256Helper
{
    public static ValueTask<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    )
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        return inputStream.ToHashAsync(sha256, cancellationToken: cancellationToken);
    }

    public static ValueTask<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    )
    {
        using var sha256 = System.Security.Cryptography.SHA256.Create();
        return inputStream.ToHashStringAsync(sha256, cancellationToken: cancellationToken);
    }
}
