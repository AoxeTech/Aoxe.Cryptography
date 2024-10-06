#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_512;

public static partial class Sha3_512Extensions
{
    public static ValueTask<byte[]> ToSha3_512Async(
        this Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha3_512Helper.ComputeHashAsync(inputStream, cancellationToken);

    public static ValueTask<string> ToSha3_512StringAsync(
        this Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha3_512Helper.ComputeHashStringAsync(inputStream, cancellationToken);
}
#endif
