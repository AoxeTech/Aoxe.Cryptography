namespace Zaabee.Cryptography.HashAlgorithm.Sha384;

public class Sha384Algorithm : IHashAlgorithm
{
    public byte[] ComputeHash(byte[] bytes) =>
        bytes.ToSha384();

    public byte[] ComputeHash(Stream inputStream) =>
        inputStream.ToSha384();

    public byte[] ComputeHash(string str) =>
        str.ToSha384();

    public string ComputeHashString(byte[] bytes) =>
        bytes.ToSha384String();

    public string ComputeHashString(Stream inputStream) =>
        inputStream.ToSha384String();

    public string ComputeHashString(string str) =>
        str.ToSha384String();

#if !NETSTANDARD2_0
    public Task<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default) =>
        inputStream.ToSha384Async(cancellationToken);

    public Task<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default) =>
        inputStream.ToSha384StringAsync(cancellationToken);
#endif
}