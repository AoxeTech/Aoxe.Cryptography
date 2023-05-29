namespace Zaabee.Cryptography.Abstractions;

public interface ISymmetricAlgorithm
{
    byte[] Encrypt(byte[] bytes, byte[] key, byte[] iv);
    byte[] Encrypt(string str, byte[] key, byte[] iv, Encoding encoding);
    byte[] Encrypt(Stream inputStream, byte[] key, byte[] iv);
    Task<byte[]> EncryptAsync(Stream inputStream, byte[] key, byte[] iv);
    byte[] Decrypt(byte[] bytes, byte[] key, byte[] iv);
    byte[] Decrypt(string str, byte[] key, byte[] iv, Encoding encoding);
    byte[] Decrypt(Stream inputStream, byte[] key, byte[] iv);
    Task<byte[]> DecryptAsync(Stream inputStream, byte[] key, byte[] iv);
}