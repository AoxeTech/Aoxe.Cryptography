namespace Aoxe.Cryptography.HashAlgorithm.SHA1;

public static partial class Sha1Extensions
{
    public static ValueTask<byte[]> ToSha1Async(
        this Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha1Helper.ComputeHashAsync(inputStream, cancellationToken);

    public static ValueTask<string> ToSha1StringAsync(
        this Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha1Helper.ComputeHashStringAsync(inputStream, cancellationToken);
}
