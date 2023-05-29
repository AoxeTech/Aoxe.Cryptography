namespace Zaabee.Cryptography.Abstractions;

public interface IAsymmetricAlgorithm
{
    byte[] Encrypt(byte[] bytes, byte[] publicKey);
    byte[] Encrypt(string str, byte[] publicKey, Encoding encoding);
    byte[] Encrypt(Stream inputStream, byte[] publicKey);
    Task<byte[]> EncryptAsync(Stream inputStream, byte[] publicKey);
    byte[] Decrypt(byte[] bytes, byte[] privateKey);
    byte[] Decrypt(string str, byte[] privateKey, Encoding encoding);
    byte[] Decrypt(Stream inputStream, byte[] privateKey);
    Task<byte[]> DecryptAsync(Stream inputStream, byte[] privateKey);
}