namespace Aoxe.Cryptography.Internals;

internal static partial class HashAlgorithmExtensions
{
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

#if NETSTANDARD2_0
    private static async Task<byte[]> ComputeHashAsync(
        this System.Security.Cryptography.HashAlgorithm hashAlgorithm,
        Stream inputStream,
        CancellationToken cancellationToken = default
    )
    {
        if (inputStream.CanSeek)
            inputStream.Seek(0, SeekOrigin.Begin);

        var buffer = new byte[8192];
        int bytesRead;

        while (
            (
                bytesRead = await inputStream
                    .ReadAsync(buffer, 0, buffer.Length, cancellationToken)
                    .ConfigureAwait(false)
            ) > 0
        )
        {
            hashAlgorithm.TransformBlock(buffer, 0, bytesRead, null, 0);
        }

        hashAlgorithm.TransformFinalBlock([], 0, 0);

        return hashAlgorithm.Hash;
    }
#endif
}
