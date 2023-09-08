namespace Zaabee.Cryptography.HashAlgorithm.SHA1;

public class Sha1Algorithm : IHashAlgorithm
{
    public byte[] ComputeHash(byte[] bytes) =>
        bytes.ToSha1();

    public byte[] ComputeHash(Stream inputStream) =>
        inputStream.ToSha1();

#if !NETSTANDARD2_0
    public Task<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default) =>
        inputStream.ToSha1Async(cancellationToken: cancellationToken);
#endif
}