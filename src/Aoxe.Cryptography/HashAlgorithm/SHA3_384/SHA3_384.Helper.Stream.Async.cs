#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_384;

public static partial class Sha3_384Helper
{
    public static ValueTask<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    )
    {
        using var sha3_384 = System.Security.Cryptography.SHA3_384.Create();
        return inputStream.ToHashAsync(sha3_384, cancellationToken: cancellationToken);
    }

    public static ValueTask<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    )
    {
        using var sha3_384 = System.Security.Cryptography.SHA3_384.Create();
        return inputStream.ToHashStringAsync(sha3_384, cancellationToken: cancellationToken);
    }
}
#endif
