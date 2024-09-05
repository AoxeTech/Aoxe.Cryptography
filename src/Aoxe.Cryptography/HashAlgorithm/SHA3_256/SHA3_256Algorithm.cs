#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.HashAlgorithm.SHA3_256;

public class Sha3_256Algorithm : IHashAlgorithm
{
    public byte[] ComputeHash(byte[] bytes) => Sha3_256Helper.ComputeHash(bytes);

    public byte[] ComputeHash(Stream inputStream) => Sha3_256Helper.ComputeHash(inputStream);

    public byte[] ComputeHash(string str) => Sha3_256Helper.ComputeHash(str);

    public string ComputeHashString(byte[] bytes) => Sha3_256Helper.ComputeHashString(bytes);

    public string ComputeHashString(Stream inputStream) =>
        Sha3_256Helper.ComputeHashString(inputStream);

    public string ComputeHashString(string str) => Sha3_256Helper.ComputeHashString(str);

    public ValueTask<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha3_256Helper.ComputeHashAsync(inputStream, cancellationToken);

    public ValueTask<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    ) => Sha3_256Helper.ComputeHashStringAsync(inputStream, cancellationToken);
}
#endif
