namespace Zaabee.Cryptography.HashAlgorithm.SHA256;

public class Sha256Algorithm : IHashAlgorithm
{
    public byte[] ComputeHash(byte[] bytes) =>
        bytes.ToSha256();

    public byte[] ComputeHash(Stream inputStream) =>
        inputStream.ToSha256();

#if !NETSTANDARD2_0
    public Task<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default) =>
        inputStream.ToSha256Async(cancellationToken);
#endif
}