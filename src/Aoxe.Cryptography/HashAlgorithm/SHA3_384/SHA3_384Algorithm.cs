#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_384;

public class Sha3_384Algorithm : IHashAlgorithm
{
    public byte[] ComputeHash(byte[] bytes) => Sha3_384Helper.ComputeHash(bytes);

    public byte[] ComputeHash(Stream inputStream) => Sha3_384Helper.ComputeHash(inputStream);

    public byte[] ComputeHash(string str) => Sha3_384Helper.ComputeHash(str);

    public string ComputeHashString(byte[] bytes) => Sha3_384Helper.ComputeHashString(bytes);

    public string ComputeHashString(Stream inputStream) =>
        Sha3_384Helper.ComputeHashString(inputStream);

    public string ComputeHashString(string str) => Sha3_384Helper.ComputeHashString(str);

    public ValueTask<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha3_384Helper.ComputeHashAsync(inputStream, cancellationToken);

    public ValueTask<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha3_384Helper.ComputeHashStringAsync(inputStream, cancellationToken);
}
#endif
