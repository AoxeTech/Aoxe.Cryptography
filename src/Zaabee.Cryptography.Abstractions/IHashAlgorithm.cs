namespace Zaabee.Cryptography.Abstractions;

public interface IHashAlgorithm
{
    string ComputeHash(byte[] bytes);
    string ComputeHash(string str, Encoding encoding);
    string ComputeHash(Stream inputStream);
    byte[] ComputeHashBytes(byte[] bytes);
    byte[] ComputeHashBytes(string str, Encoding encoding);
    byte[] ComputeHashBytes(Stream inputStream);
    Task<string> ComputeHashAsync(Stream inputStream);
    Task<byte[]> ComputeHashBytesAsync(Stream inputStream);
}