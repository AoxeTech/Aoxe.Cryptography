namespace Zaabee.Cryptography.HashAlgorithm.MD5;

public class Md5Algorithm : IHashAlgorithm
{
    public byte[] ComputeHash(byte[] bytes) =>
        bytes.ToMd5();

    public byte[] ComputeHash(Stream inputStream) =>
        inputStream.ToMd5();

#if !NETSTANDARD2_0
    public Task<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default) =>
        inputStream.ToMd5Async(cancellationToken: cancellationToken);
#endif
}