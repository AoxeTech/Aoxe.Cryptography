namespace Aoxe.Cryptography.HashAlgorithm.MD5;

public static partial class Md5Extensions
{
#if !NETSTANDARD2_0
    public static ValueTask<byte[]> ToMd5Async(
        this Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Md5Helper.ComputeHashAsync(inputStream, cancellationToken);

    public static ValueTask<string> ToMd5StringAsync(
        this Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Md5Helper.ComputeHashStringAsync(inputStream, cancellationToken);
#endif
}
