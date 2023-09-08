namespace Zaabee.Cryptography.HashAlgorithm.Sha256;

public class Sha256Algorithm : IHashAlgorithm
{
    public byte[] ComputeHash(byte[] bytes) =>
        bytes.ToSha256();

    public byte[] ComputeHash(Stream inputStream) =>
        inputStream.ToSha256();

    public byte[] ComputeHash(string str) =>
        str.ToSha256();

    public string ComputeHashString(byte[] bytes) =>
        bytes.ToSha256String();

    public string ComputeHashString(Stream inputStream) =>
        inputStream.ToSha256String();

    public string ComputeHashString(string str) =>
        str.ToSha256String();

#if !NETSTANDARD2_0
    public Task<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default) =>
        inputStream.ToSha256Async(cancellationToken);

    public Task<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default) =>
        inputStream.ToSha256StringAsync(cancellationToken);
#endif
}