namespace Zaabee.Cryptography;

public static partial class HashAlgorithmExtensions
{
#if !NETSTANDARD2_0
    public static Task<byte[]> ToHashAsync(
        this HashAlgorithm hashAlgorithm,
        Stream inputStream,
        CancellationToken cancellationToken = default) =>
        hashAlgorithm.ComputeHashAsync(inputStream, cancellationToken);
#endif
}