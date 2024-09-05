#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_256;

public static partial class Sha3_256Helper
{
    public static ValueTask<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    )
    {
        using var sha3_256 = System.Security.Cryptography.SHA3_256.Create();
        return inputStream.ToHashAsync(sha3_256, cancellationToken: cancellationToken);
    }

    public static ValueTask<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    )
    {
        using var sha3_256 = System.Security.Cryptography.SHA3_256.Create();
        return inputStream.ToHashStringAsync(sha3_256, cancellationToken: cancellationToken);
    }
}
#endif
