#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_256;

public static partial class Sha3_256Extensions
{
    public static ValueTask<byte[]> ToSha3_256Async(
        this Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha3_256Helper.ComputeHashAsync(inputStream, cancellationToken);

    public static ValueTask<string> ToSha3_256StringAsync(
        this Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha3_256Helper.ComputeHashStringAsync(inputStream, cancellationToken);
}
#endif
