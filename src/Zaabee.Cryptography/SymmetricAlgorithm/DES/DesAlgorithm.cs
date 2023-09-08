namespace Zaabee.Cryptography.SymmetricAlgorithm.DES;

public class DesAlgorithm : ISymmetricAlgorithm
{
    private readonly CipherMode _cipherMode;
    private readonly PaddingMode _paddingMode;

    public DesAlgorithm(PaddingMode paddingMode = PaddingMode.PKCS7, CipherMode cipherMode = CipherMode.CBC)
    {
        _paddingMode = paddingMode;
        _cipherMode = cipherMode;
    }

    public byte[] Encrypt(byte[] bytes, byte[] key, byte[] iv) =>
        DesHelper.Encrypt(bytes, key, iv, _cipherMode, _paddingMode);

    public MemoryStream Encrypt(Stream inputStream, byte[] key, byte[] iv) =>
        DesHelper.Encrypt(inputStream, key, iv, _cipherMode, _paddingMode);

    public ValueTask<MemoryStream> EncryptAsync(Stream inputStream, byte[] key, byte[] iv) =>
        DesHelper.EncryptAsync(inputStream, key, iv, _cipherMode, _paddingMode);

    public byte[] Decrypt(byte[] bytes, byte[] key, byte[] iv) =>
        DesHelper.Decrypt(bytes, key, iv, _cipherMode, _paddingMode);

    public MemoryStream Decrypt(Stream inputStream, byte[] key, byte[] iv) =>
        DesHelper.Decrypt(inputStream, key, iv, _cipherMode, _paddingMode);

    public ValueTask<MemoryStream> DecryptAsync(Stream inputStream, byte[] key, byte[] iv) =>
        DesHelper.DecryptAsync(inputStream, key, iv, _cipherMode, _paddingMode);

    public byte[] GenerateKey() =>
        DesHelper.GenerateKey();

    public byte[] GenerateVector() =>
        DesHelper.GenerateVector();

    public (byte[] key, byte[] vector) GenerateKeyAndVector() =>
        DesHelper.GenerateKeyAndVector();
}