# if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Shake256;

public static partial class Shake256Extensions
{
    public static ValueTask<byte[]> ToShake256Async(
        this Stream inputStream,
        int outputLength,
        CancellationToken cancellationToken = default
    ) => Shake256Helper.ComputeHashAsync(inputStream, outputLength, cancellationToken);

    public static ValueTask<string> ToShake256StringAsync(
        this Stream inputStream,
        int outputLength,
        CancellationToken cancellationToken = default
    ) => Shake256Helper.ComputeHashStringAsync(inputStream, outputLength, cancellationToken);

    public static ValueTask ToShake256Async(
        this Stream inputStream,
        Memory<byte> destination,
        CancellationToken cancellationToken = default
    ) => Shake256Helper.ComputeHashAsync(inputStream, destination, cancellationToken);
}
# endif
