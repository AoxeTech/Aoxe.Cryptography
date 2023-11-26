namespace Zaabee.Cryptography.Abstractions;

public sealed class NullHashAlgorithm : IHashAlgorithm
{
    public byte[] ComputeHash(byte[] bytes) => bytes.ToHex();

    public byte[] ComputeHash(Stream inputStream) => inputStream.ReadToEnd().ToHex();

    public byte[] ComputeHash(string str) => str.ToHex();

    public string ComputeHashString(byte[] bytes) => bytes.ToHexString();

    public string ComputeHashString(Stream inputStream) => inputStream.ReadToEnd().ToHexString();

    public string ComputeHashString(string str) => str.ToHexString();

#if !NETSTANDARD2_0
    public async ValueTask<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    ) => (await inputStream.ReadToEndAsync(cancellationToken)).ToHex();

    public async ValueTask<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default
    ) => (await inputStream.ReadToEndAsync(cancellationToken)).ToHexString();
#endif
}
