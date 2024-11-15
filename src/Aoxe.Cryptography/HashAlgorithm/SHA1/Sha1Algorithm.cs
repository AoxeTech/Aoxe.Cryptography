namespace Aoxe.Cryptography.HashAlgorithm.Sha1;

public class Sha1Algorithm : IHashAlgorithm
{
    public byte[] ComputeHash(byte[] bytes) => Sha1Helper.ComputeHash(bytes);

    public byte[] ComputeHash(Stream inputStream) => Sha1Helper.ComputeHash(inputStream);

    public byte[] ComputeHash(string str) => Sha1Helper.ComputeHash(str);

    public string ComputeHashString(byte[] bytes) => Sha1Helper.ComputeHashString(bytes);

    public string ComputeHashString(Stream inputStream) =>
        Sha1Helper.ComputeHashString(inputStream);

    public string ComputeHashString(string str) => Sha1Helper.ComputeHashString(str);

    public ValueTask<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha1Helper.ComputeHashAsync(inputStream, cancellationToken);

    public ValueTask<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha1Helper.ComputeHashStringAsync(inputStream, cancellationToken);
}
