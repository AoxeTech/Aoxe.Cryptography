namespace Aoxe.Cryptography.HashAlgorithm.SHA512;

public static partial class Sha512Helper
{
    public static ValueTask<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    )
    {
        using var sha512 = System.Security.Cryptography.SHA512.Create();
        return inputStream.ToHashAsync(sha512, cancellationToken: cancellationToken);
    }

    public static ValueTask<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    )
    {
        using var sha512 = System.Security.Cryptography.SHA512.Create();
        return inputStream.ToHashStringAsync(sha512, cancellationToken: cancellationToken);
    }
}
