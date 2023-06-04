namespace Zaabee.Cryptography.Internals;

internal static partial class HashAlgorithmExtensions
{
#if !NETSTANDARD2_0
    internal static Task<byte[]> ToHashAsync(
        this Stream inputStream,
        System.Security.Cryptography.HashAlgorithm hashAlgorithm,
        CancellationToken cancellationToken = default) =>
        hashAlgorithm.ComputeHashAsync(inputStream, cancellationToken);
#endif
}