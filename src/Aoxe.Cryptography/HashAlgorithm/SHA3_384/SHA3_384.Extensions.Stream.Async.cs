#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_384;

public static partial class Sha3_384Extensions
{
    public static ValueTask<byte[]> ToSha3_384Async(
        this Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha3_384Helper.ComputeHashAsync(inputStream, cancellationToken);

    public static ValueTask<string> ToSha3_384StringAsync(
        this Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha3_384Helper.ComputeHashStringAsync(inputStream, cancellationToken);
}
#endif
