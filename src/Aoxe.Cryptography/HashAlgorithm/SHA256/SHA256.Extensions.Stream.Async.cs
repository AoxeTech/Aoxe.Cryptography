namespace Aoxe.Cryptography.HashAlgorithm.SHA256;

public static partial class Sha256Extensions
{
#if !NETSTANDARD2_0
    public static ValueTask<byte[]> ToSha256Async(
        this Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha256Helper.ComputeHashAsync(inputStream, cancellationToken);

    public static ValueTask<string> ToSha256StringAsync(
        this Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha256Helper.ComputeHashStringAsync(inputStream, cancellationToken);
#endif
}
