namespace Aoxe.Cryptography.HashAlgorithm.SHA384;

public static partial class Sha384Helper
{
#if !NETSTANDARD2_0
    public static ValueTask<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    )
    {
        using var sha384 = System.Security.Cryptography.SHA384.Create();
        return inputStream.ToHashAsync(sha384, cancellationToken: cancellationToken);
    }

    public static ValueTask<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    )
    {
        using var sha384 = System.Security.Cryptography.SHA384.Create();
        return inputStream.ToHashStringAsync(sha384, cancellationToken: cancellationToken);
    }
#endif
}
