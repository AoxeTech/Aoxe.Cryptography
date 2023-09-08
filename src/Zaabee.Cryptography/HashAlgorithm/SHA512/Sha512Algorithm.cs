namespace Zaabee.Cryptography.HashAlgorithm.SHA512;

public class Sha512Algorithm : IHashAlgorithm
{
    public byte[] ComputeHash(byte[] bytes) =>
        bytes.ToSha512();

    public byte[] ComputeHash(Stream inputStream) =>
        inputStream.ToSha512();

#if !NETSTANDARD2_0
    public Task<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default) =>
        inputStream.ToSha512Async(cancellationToken);
#endif
}