namespace Zaabee.Cryptography.Internals;

internal static partial class HashAlgorithmExtensions
{
#if !NETSTANDARD2_0
    internal static async ValueTask<byte[]> ToHashAsync(
        this Stream inputStream,
        System.Security.Cryptography.HashAlgorithm hashAlgorithm,
        CancellationToken cancellationToken = default
    )
    {
        var hashBytes = await hashAlgorithm.ComputeHashAsync(inputStream, cancellationToken);
        inputStream.TrySeek(0, SeekOrigin.Begin);
        return hashBytes;
    }

    internal static async ValueTask<string> ToHashStringAsync(
        this Stream inputStream,
        System.Security.Cryptography.HashAlgorithm hashAlgorithm,
        CancellationToken cancellationToken = default
    )
    {
        var hashString = (
            await hashAlgorithm.ComputeHashAsync(inputStream, cancellationToken)
        ).ToHexString();
        inputStream.TrySeek(0, SeekOrigin.Begin);
        return hashString;
    }
#endif
}
