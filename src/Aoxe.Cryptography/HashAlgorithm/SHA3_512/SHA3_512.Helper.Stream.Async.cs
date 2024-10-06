#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_512;

public static partial class Sha3_512Helper
{
    public static ValueTask<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    )
    {
        using var sha3_512 = System.Security.Cryptography.SHA3_512.Create();
        return inputStream.ToHashAsync(sha3_512, cancellationToken: cancellationToken);
    }

    public static ValueTask<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    )
    {
        using var sha3_512 = System.Security.Cryptography.SHA3_512.Create();
        return inputStream.ToHashStringAsync(sha3_512, cancellationToken: cancellationToken);
    }
}
#endif
