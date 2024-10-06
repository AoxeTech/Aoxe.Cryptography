# if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Shake128;

public static partial class Shake128Helper
{
    public static ValueTask<byte[]> ComputeHashAsync(
        Stream source,
        int outputLength,
        CancellationToken cancellationToken = default
    ) =>
        System
            .Security
            .Cryptography
            .Shake128
            .HashDataAsync(source, outputLength, cancellationToken);

    public static async ValueTask<string> ComputeHashStringAsync(
        Stream source,
        int outputLength,
        CancellationToken cancellationToken = default
    ) => (await ComputeHashAsync(source, outputLength, cancellationToken)).ToHexString();

    public static ValueTask ComputeHashAsync(
        Stream source,
        Memory<byte> destination,
        CancellationToken cancellationToken = default
    ) =>
        System.Security.Cryptography.Shake128.HashDataAsync(source, destination, cancellationToken);
}
#endif
