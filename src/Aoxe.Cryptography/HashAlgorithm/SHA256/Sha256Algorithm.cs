namespace Aoxe.Cryptography.HashAlgorithm.Sha256;

public class Sha256Algorithm : IHashAlgorithm
{
    public byte[] ComputeHash(byte[] bytes) => Sha256Helper.ComputeHash(bytes);

    public byte[] ComputeHash(Stream inputStream) => Sha256Helper.ComputeHash(inputStream);

    public byte[] ComputeHash(string str) => Sha256Helper.ComputeHash(str);

    public string ComputeHashString(byte[] bytes) => Sha256Helper.ComputeHashString(bytes);

    public string ComputeHashString(Stream inputStream) =>
        Sha256Helper.ComputeHashString(inputStream);

    public string ComputeHashString(string str) => Sha256Helper.ComputeHashString(str);

    public ValueTask<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha256Helper.ComputeHashAsync(inputStream, cancellationToken);

    public ValueTask<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha256Helper.ComputeHashStringAsync(inputStream, cancellationToken);
}
