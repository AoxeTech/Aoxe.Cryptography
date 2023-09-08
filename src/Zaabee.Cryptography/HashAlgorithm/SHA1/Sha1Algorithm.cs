namespace Zaabee.Cryptography.HashAlgorithm.Sha1;

public class Sha1Algorithm : IHashAlgorithm
{
    public byte[] ComputeHash(byte[] bytes) =>
        bytes.ToSha1();

    public byte[] ComputeHash(Stream inputStream) =>
        inputStream.ToSha1();

    public byte[] ComputeHash(string str) =>
        str.ToSha1();

    public string ComputeHashString(byte[] bytes) =>
        bytes.ToSha1String();

    public string ComputeHashString(Stream inputStream) =>
        inputStream.ToSha1String();

    public string ComputeHashString(string str) =>
        str.ToSha1String();

#if !NETSTANDARD2_0
    public Task<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default) =>
        inputStream.ToSha1Async(cancellationToken);

    public Task<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default) =>
        inputStream.ToSha1StringAsync(cancellationToken);
#endif
}