namespace Zaabee.Cryptography.HashAlgorithm.SHA384;

public static partial class Sha384Extensions
{
#if !NETSTANDARD2_0
    public static ValueTask<byte[]> ToSha384Async(
        this Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha384Helper.ComputeHashAsync(inputStream, cancellationToken);

    public static ValueTask<string> ToSha384StringAsync(
        this Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha384Helper.ComputeHashStringAsync(inputStream, cancellationToken);
#endif
}
