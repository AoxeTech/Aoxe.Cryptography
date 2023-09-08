namespace Zaabee.Cryptography.Abstractions;

public interface IHashAlgorithm
{
    byte[] ComputeHash(byte[] bytes);
    byte[] ComputeHash(Stream inputStream);

#if !NETSTANDARD2_0
    Task<byte[]> ComputeHashAsync(Stream inputStream, CancellationToken cancellationToken = default);
#endif
}