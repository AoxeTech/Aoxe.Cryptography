namespace Aoxe.Cryptography.Abstractions;

public class NullHashAlgorithm : IHashAlgorithm
{
    public byte[] ComputeHash(byte[] bytes) => [];

    public byte[] ComputeHash(Stream inputStream) => [];

    public byte[] ComputeHash(string str) => [];

    public string ComputeHashString(byte[] bytes) => string.Empty;

    public string ComputeHashString(Stream inputStream) => string.Empty;

    public string ComputeHashString(string str) => string.Empty;

    public ValueTask<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    ) => new([]);

    public ValueTask<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    ) => new(string.Empty);
}
