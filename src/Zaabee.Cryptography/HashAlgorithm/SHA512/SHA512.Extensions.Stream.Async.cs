namespace Zaabee.Cryptography.HashAlgorithm.SHA512;

public static partial class Sha512Extensions
{
#if !NETSTANDARD2_0
    public static Task<byte[]> ToSha512Async(
        this Stream inputStream,
        CancellationToken cancellationToken = default) =>
        Sha512Helper.ComputeHashAsync(inputStream, cancellationToken);

    public static Task<string> ToSha512StringAsync(
        this Stream inputStream,
        CancellationToken cancellationToken = default) =>
        Sha512Helper.ComputeHashStringAsync(inputStream, cancellationToken);
#endif
}