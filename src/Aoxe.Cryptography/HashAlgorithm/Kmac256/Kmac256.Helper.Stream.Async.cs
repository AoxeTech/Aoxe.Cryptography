# if NET9_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Kmac256;

public static partial class Kmac256Helper
{
    public static ValueTask<byte[]> ComputeHashAsync(
        byte[] key,
        Stream source,
        int outputLength,
        byte[]? customizationString = default,
        CancellationToken cancellationToken = default
    ) =>
        System
            .Security
            .Cryptography
            .Kmac256
            .HashDataAsync(key, source, outputLength, customizationString, cancellationToken);

    public static ValueTask<byte[]> ComputeHashAsync(
        ReadOnlyMemory<byte> key,
        Stream source,
        int outputLength,
        ReadOnlyMemory<byte> customizationString = default,
        CancellationToken cancellationToken = default
    ) =>
        System
            .Security
            .Cryptography
            .Kmac256
            .HashDataAsync(key, source, outputLength, customizationString, cancellationToken);

    public static async ValueTask<string> ComputeHashStringAsync(
        byte[] key,
        Stream source,
        int outputLength,
        byte[]? customizationString = default,
        CancellationToken cancellationToken = default
    ) =>
        (
            await ComputeHashAsync(
                key,
                source,
                outputLength,
                customizationString,
                cancellationToken
            )
        ).ToHexString();

    public static async ValueTask<string> ComputeHashStringAsync(
        ReadOnlyMemory<byte> key,
        Stream source,
        int outputLength,
        ReadOnlyMemory<byte> customizationString = default,
        CancellationToken cancellationToken = default
    ) =>
        (
            await ComputeHashAsync(
                key,
                source,
                outputLength,
                customizationString,
                cancellationToken
            )
        ).ToHexString();

    public static ValueTask ComputeHashAsync(
        ReadOnlyMemory<byte> key,
        Stream source,
        Memory<byte> destination,
        ReadOnlyMemory<byte> customizationString = default,
        CancellationToken cancellationToken = default
    ) =>
        System
            .Security
            .Cryptography
            .Kmac256
            .HashDataAsync(key, source, destination, customizationString, cancellationToken);
}
#endif
