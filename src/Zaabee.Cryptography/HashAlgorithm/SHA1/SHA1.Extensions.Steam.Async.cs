namespace Zaabee.Cryptography.HashAlgorithm.SHA1;

public static partial class Sha1Extensions
{
#if !NETSTANDARD2_0
    public static Task<byte[]> ToSha1Async(
        this Stream inputStream,
        CancellationToken cancellationToken = default) =>
        Sha1Helper.ComputeHashAsync(inputStream, cancellationToken);

    public static Task<string> ToSha1StringAsync(
        this Stream inputStream,
        CancellationToken cancellationToken = default) =>
        Sha1Helper.ComputeHashStringAsync(inputStream, cancellationToken);
#endif
}