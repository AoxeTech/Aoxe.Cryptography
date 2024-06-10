namespace Aoxe.Cryptography.Abstractions;

public class NullSymmetricAlgorithm : ISymmetricAlgorithm
{
    public byte[] Encrypt(byte[] bytes, byte[] key, byte[] iv) => bytes.CloneNew();

    public MemoryStream Encrypt(Stream inputStream, byte[] key, byte[] iv) =>
        inputStream.ToMemoryStream();

    public async ValueTask<MemoryStream> EncryptAsync(Stream inputStream, byte[] key, byte[] iv) =>
        await inputStream.ToMemoryStreamAsync();

    public byte[] Decrypt(byte[] bytes, byte[] key, byte[] iv) => bytes.CloneNew();

    public MemoryStream Decrypt(Stream inputStream, byte[] key, byte[] iv) =>
        inputStream.ToMemoryStream();

    public async ValueTask<MemoryStream> DecryptAsync(Stream inputStream, byte[] key, byte[] iv) =>
        await inputStream.ToMemoryStreamAsync();

    public byte[] GenerateKey() => Array.Empty<byte>();

    public byte[] GenerateVector() => Array.Empty<byte>();

    public (byte[] key, byte[] vector) GenerateKeyAndVector() =>
        (Array.Empty<byte>(), Array.Empty<byte>());
}
