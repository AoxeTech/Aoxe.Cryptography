namespace Zaabee.Cryptography.HashAlgorithm.Sha384;

public class Sha384Algorithm : IHashAlgorithm
{
    public byte[] ComputeHash(byte[] bytes) =>
        Sha384Helper.ComputeHash(bytes);

    public byte[] ComputeHash(Stream inputStream) =>
        Sha384Helper.ComputeHash(inputStream);

    public byte[] ComputeHash(string str) =>
        Sha384Helper.ComputeHash(str);

    public string ComputeHashString(byte[] bytes) =>
        Sha384Helper.ComputeHashString(bytes);

    public string ComputeHashString(Stream inputStream) =>
        Sha384Helper.ComputeHashString(inputStream);

    public string ComputeHashString(string str) =>
        Sha384Helper.ComputeHashString(str);

#if !NETSTANDARD2_0
    public Task<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default) =>
        Sha384Helper.ComputeHashAsync(inputStream, cancellationToken);

    public Task<string> ComputeHashStringAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default) =>
        Sha384Helper.ComputeHashStringAsync(inputStream, cancellationToken);
#endif
}