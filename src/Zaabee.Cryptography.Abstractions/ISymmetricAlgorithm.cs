namespace Zaabee.Cryptography.Abstractions;

public interface ISymmetricAlgorithm
{
    byte[] Encrypt(byte[] bytes, byte[] key, byte[] iv);
    MemoryStream Encrypt(Stream inputStream, byte[] key, byte[] iv);
    ValueTask<MemoryStream> EncryptAsync(Stream inputStream, byte[] key, byte[] iv);
    byte[] Decrypt(byte[] bytes, byte[] key, byte[] iv);
    MemoryStream Decrypt(Stream inputStream, byte[] key, byte[] iv);
    ValueTask<MemoryStream> DecryptAsync(Stream inputStream, byte[] key, byte[] iv);
    byte[] GenerateKey();
    byte[] GenerateVector();
    (byte[] key, byte[] vector) GenerateKeyAndVector();
}
