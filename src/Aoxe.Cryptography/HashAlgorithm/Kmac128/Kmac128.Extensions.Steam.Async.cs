# if NET9_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.Kmac128;

public static partial class Kmac128Extensions
{
    public static ValueTask<byte[]> ToKmac128Async(
        this Stream inputStream,
        byte[] key,
        int outputLength,
        byte[]? customizationString = default,
        CancellationToken cancellationToken = default
    ) =>
        Kmac128Helper.ComputeHashAsync(
            key,
            inputStream,
            outputLength,
            customizationString,
            cancellationToken
        );

    public static ValueTask<byte[]> ToKmac128Async(
        this Stream inputStream,
        ReadOnlyMemory<byte> key,
        int outputLength,
        ReadOnlyMemory<byte> customizationString = default,
        CancellationToken cancellationToken = default
    ) =>
        Kmac128Helper.ComputeHashAsync(
            key,
            inputStream,
            outputLength,
            customizationString,
            cancellationToken
        );

    public static ValueTask<string> ToKmac128StringAsync(
        this Stream inputStream,
        byte[] key,
        int outputLength,
        byte[]? customizationString = default,
        CancellationToken cancellationToken = default
    ) =>
        Kmac128Helper.ComputeHashStringAsync(
            key,
            inputStream,
            outputLength,
            customizationString,
            cancellationToken
        );

    public static ValueTask<string> ToKmac128StringAsync(
        this Stream inputStream,
        ReadOnlyMemory<byte> key,
        int outputLength,
        ReadOnlyMemory<byte> customizationString = default,
        CancellationToken cancellationToken = default
    ) =>
        Kmac128Helper.ComputeHashStringAsync(
            key,
            inputStream,
            outputLength,
            customizationString,
            cancellationToken
        );

    public static ValueTask ToKmac128Async(
        this Stream inputStream,
        ReadOnlyMemory<byte> key,
        Memory<byte> destination,
        ReadOnlyMemory<byte> customizationString = default,
        CancellationToken cancellationToken = default
    ) =>
        Kmac128Helper.ComputeHashAsync(
            key,
            inputStream,
            destination,
            customizationString,
            cancellationToken
        );
}
# endif
