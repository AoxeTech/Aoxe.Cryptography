namespace Zaabee.Cryptography.HashAlgorithm.MD5;

public class Md5Algorithm : IHashAlgorithm
{
    public byte[] ComputeHash(byte[] bytes) => Md5Helper.ComputeHash(bytes);

    public byte[] ComputeHash(Stream inputStream) => Md5Helper.ComputeHash(inputStream);

    public byte[] ComputeHash(string str) => Md5Helper.ComputeHash(str);

    public string ComputeHashString(byte[] bytes) => Md5Helper.ComputeHashString(bytes);

    public string ComputeHashString(Stream inputStream) => Md5Helper.ComputeHashString(inputStream);

    public string ComputeHashString(string str) => Md5Helper.ComputeHashString(str);

#if !NETSTANDARD2_0
    public ValueTask<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Md5Helper.ComputeHashAsync(inputStream, cancellationToken);

    public ValueTask<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Md5Helper.ComputeHashStringAsync(inputStream, cancellationToken);
#endif
}
