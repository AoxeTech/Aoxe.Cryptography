namespace Zaabee.Cryptography.HashAlgorithm.Sha512;

public class Sha512Algorithm : IHashAlgorithm
{
    public byte[] ComputeHash(byte[] bytes) =>
        bytes.ToSha512();

    public byte[] ComputeHash(Stream inputStream) =>
        inputStream.ToSha512();

    public byte[] ComputeHash(string str) =>
        str.ToSha512();

    public string ComputeHashString(byte[] bytes) =>
        bytes.ToSha512String();

    public string ComputeHashString(Stream inputStream) =>
        inputStream.ToSha512String();

    public string ComputeHashString(string str) =>
        str.ToSha512String();

#if !NETSTANDARD2_0
    public Task<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default) =>
        inputStream.ToSha512Async(cancellationToken);

    public Task<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default) =>
        inputStream.ToSha512StringAsync(cancellationToken);
#endif
}