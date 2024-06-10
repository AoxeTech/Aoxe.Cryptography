namespace Aoxe.Cryptography.HashAlgorithm.Sha512;

public class Sha512Algorithm : IHashAlgorithm
{
    public byte[] ComputeHash(byte[] bytes) => Sha512Helper.ComputeHash(bytes);

    public byte[] ComputeHash(Stream inputStream) => Sha512Helper.ComputeHash(inputStream);

    public byte[] ComputeHash(string str) => Sha512Helper.ComputeHash(str);

    public string ComputeHashString(byte[] bytes) => Sha512Helper.ComputeHashString(bytes);

    public string ComputeHashString(Stream inputStream) =>
        Sha512Helper.ComputeHashString(inputStream);

    public string ComputeHashString(string str) => Sha512Helper.ComputeHashString(str);

#if !NETSTANDARD2_0
    public ValueTask<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha512Helper.ComputeHashAsync(inputStream, cancellationToken);

    public ValueTask<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha512Helper.ComputeHashStringAsync(inputStream, cancellationToken);
#endif
}
