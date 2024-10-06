# if NET9_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Kmac256;

public static partial class Kmac256Extensions
{
    public static ValueTask<byte[]> ToKmac256Async(
        this Stream inputStream,
        byte[] key,
        int outputLength,
        byte[]? customizationString = default,
        CancellationToken cancellationToken = default
    ) =>
        Kmac256Helper.ComputeHashAsync(
            key,
            inputStream,
            outputLength,
            customizationString,
            cancellationToken
        );

    public static ValueTask<byte[]> ToKmac256Async(
        this Stream inputStream,
        ReadOnlyMemory<byte> key,
        int outputLength,
        ReadOnlyMemory<byte> customizationString = default,
        CancellationToken cancellationToken = default
    ) =>
        Kmac256Helper.ComputeHashAsync(
            key,
            inputStream,
            outputLength,
            customizationString,
            cancellationToken
        );

    public static ValueTask<string> ToKmac256StringAsync(
        this Stream inputStream,
        byte[] key,
        int outputLength,
        byte[]? customizationString = default,
        CancellationToken cancellationToken = default
    ) =>
        Kmac256Helper.ComputeHashStringAsync(
            key,
            inputStream,
            outputLength,
            customizationString,
            cancellationToken
        );

    public static ValueTask<string> ToKmac256StringAsync(
        this Stream inputStream,
        ReadOnlyMemory<byte> key,
        int outputLength,
        ReadOnlyMemory<byte> customizationString = default,
        CancellationToken cancellationToken = default
    ) =>
        Kmac256Helper.ComputeHashStringAsync(
            key,
            inputStream,
            outputLength,
            customizationString,
            cancellationToken
        );

    public static ValueTask ToKmac256Async(
        this Stream inputStream,
        ReadOnlyMemory<byte> key,
        Memory<byte> destination,
        ReadOnlyMemory<byte> customizationString = default,
        CancellationToken cancellationToken = default
    ) =>
        Kmac256Helper.ComputeHashAsync(
            key,
            inputStream,
            destination,
            customizationString,
            cancellationToken
        );
}
# endif
