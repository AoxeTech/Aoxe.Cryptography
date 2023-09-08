namespace Zaabee.Cryptography.SymmetricAlgorithm.AES;

public class AesAlgorithm : ISymmetricAlgorithm
{
    private readonly CipherMode _cipherMode;
    private readonly PaddingMode _paddingMode;

    public AesAlgorithm(PaddingMode paddingMode = PaddingMode.PKCS7, CipherMode cipherMode = CipherMode.CBC)
    {
        _paddingMode = paddingMode;
        _cipherMode = cipherMode;
    }

    public byte[] Encrypt(byte[] bytes, byte[] key, byte[] iv) =>
        AesHelper.Encrypt(bytes, key, iv, _cipherMode, _paddingMode);

    public MemoryStream Encrypt(Stream inputStream, byte[] key, byte[] iv) =>
        AesHelper.Encrypt(inputStream, key, iv, _cipherMode, _paddingMode);

    public Task<MemoryStream> EncryptAsync(Stream inputStream, byte[] key, byte[] iv) =>
        AesHelper.EncryptAsync(inputStream, key, iv, _cipherMode, _paddingMode);

    public byte[] Decrypt(byte[] bytes, byte[] key, byte[] iv) =>
        AesHelper.Decrypt(bytes, key, iv, _cipherMode, _paddingMode);

    public MemoryStream Decrypt(Stream inputStream, byte[] key, byte[] iv) =>
        AesHelper.Decrypt(inputStream, key, iv, _cipherMode, _paddingMode);

    public Task<MemoryStream> DecryptAsync(Stream inputStream, byte[] key, byte[] iv) =>
        AesHelper.DecryptAsync(inputStream, key, iv, _cipherMode, _paddingMode);

    public byte[] GenerateKey() =>
        AesHelper.GenerateKey();

    public byte[] GenerateVector() =>
        AesHelper.GenerateVector();

    public (byte[] key, byte[] vector) GenerateKeyAndVector() =>
        AesHelper.GenerateKeyAndVector();
}