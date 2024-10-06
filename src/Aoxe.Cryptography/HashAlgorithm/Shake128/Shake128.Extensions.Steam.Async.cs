# if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Shake128;

public static partial class Shake128Extensions
{
    public static ValueTask<byte[]> ToShake128Async(
        this Stream inputStream,
        int outputLength,
        CancellationToken cancellationToken = default
    ) => Shake128Helper.ComputeHashAsync(inputStream, outputLength, cancellationToken);

    public static ValueTask<string> ToShake128StringAsync(
        this Stream inputStream,
        int outputLength,
        CancellationToken cancellationToken = default
    ) => Shake128Helper.ComputeHashStringAsync(inputStream, outputLength, cancellationToken);

    public static ValueTask ToShake128Async(
        this Stream inputStream,
        Memory<byte> destination,
        CancellationToken cancellationToken = default
    ) => Shake128Helper.ComputeHashAsync(inputStream, destination, cancellationToken);
}
# endif
