#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_512;

public class Sha3_512Algorithm : IHashAlgorithm
{
    public byte[] ComputeHash(byte[] bytes) => Sha3_512Helper.ComputeHash(bytes);

    public byte[] ComputeHash(Stream inputStream) => Sha3_512Helper.ComputeHash(inputStream);

    public byte[] ComputeHash(string str) => Sha3_512Helper.ComputeHash(str);

    public string ComputeHashString(byte[] bytes) => Sha3_512Helper.ComputeHashString(bytes);

    public string ComputeHashString(Stream inputStream) =>
        Sha3_512Helper.ComputeHashString(inputStream);

    public string ComputeHashString(string str) => Sha3_512Helper.ComputeHashString(str);

    public ValueTask<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha3_512Helper.ComputeHashAsync(inputStream, cancellationToken);

    public ValueTask<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha3_512Helper.ComputeHashStringAsync(inputStream, cancellationToken);
}
#endif
