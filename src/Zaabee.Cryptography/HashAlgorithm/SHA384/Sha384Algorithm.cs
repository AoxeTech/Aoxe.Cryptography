namespace Zaabee.Cryptography.HashAlgorithm.SHA384;

public class Sha384Algorithm : IHashAlgorithm
{
    public byte[] ComputeHash(byte[] bytes) =>
        bytes.ToSha384();

    public byte[] ComputeHash(Stream inputStream) =>
        inputStream.ToSha384();

#if !NETSTANDARD2_0
    public Task<byte[]> ComputeHashAsync(
        Stream inputStream,
        CancellationToken cancellationToken = default) =>
        inputStream.ToSha384Async(cancellationToken);
#endif
}