namespace Zaabee.Cryptography.Abstractions;

public interface IHashAlgorithm
{
    string ComputeHashString(byte[] bytes);
    string ComputeHashString(string str, Encoding encoding);
    string ComputeHashString(Stream inputStream);
    byte[] ComputeHash(byte[] bytes);
    byte[] ComputeHash(string str, Encoding encoding);
    byte[] ComputeHash(Stream inputStream);
    Task<string> ComputeHashStringAsync(Stream inputStream);
    Task<byte[]> ComputeHashAsync(Stream inputStream);
}