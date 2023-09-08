namespace Zaabee.Cryptography.HashAlgorithm.MD5;

public class Md5Algorithm : IHashAlgorithm
{
    public byte[] ComputeHash(byte[] bytes) =>
        bytes.ToMd5();

    public byte[] ComputeHash(Stream inputStream) =>
        inputStream.ToMd5();

    public byte[] ComputeHash(string str) =>
        str.ToMd5();

    public string ComputeHashString(byte[] bytes) =>
        bytes.ToMd5String();

    public string ComputeHashString(Stream inputStream) =>
        inputStream.ToMd5String();

    public string ComputeHashString(string str) =>
        str.ToMd5String();

#if !NETSTANDARD2_0
    public Task<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default) =>
        inputStream.ToMd5Async(cancellationToken);

    public Task<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default) =>
        inputStream.ToMd5StringAsync(cancellationToken);
#endif
}