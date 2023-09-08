namespace Zaabee.Cryptography.SymmetricAlgorithm.TripleDES;

public class TripleDesAlgorithm : ISymmetricAlgorithm
{
    private readonly CipherMode _cipherMode;
    private readonly PaddingMode _paddingMode;

    public TripleDesAlgorithm(PaddingMode paddingMode = PaddingMode.PKCS7, CipherMode cipherMode = CipherMode.CBC)
    {
        _paddingMode = paddingMode;
        _cipherMode = cipherMode;
    }

    public byte[] Encrypt(byte[] bytes, byte[] key, byte[] iv) =>
        TripleDesHelper.Encrypt(bytes, key, iv, _cipherMode, _paddingMode);

    public MemoryStream Encrypt(Stream inputStream, byte[] key, byte[] iv) =>
        TripleDesHelper.Encrypt(inputStream, key, iv, _cipherMode, _paddingMode);

    public Task<MemoryStream> EncryptAsync(Stream inputStream, byte[] key, byte[] iv) =>
        TripleDesHelper.EncryptAsync(inputStream, key, iv, _cipherMode, _paddingMode);

    public byte[] Decrypt(byte[] bytes, byte[] key, byte[] iv) =>
        TripleDesHelper.Decrypt(bytes, key, iv, _cipherMode, _paddingMode);

    public MemoryStream Decrypt(Stream inputStream, byte[] key, byte[] iv) =>
        TripleDesHelper.Decrypt(inputStream, key, iv, _cipherMode, _paddingMode);

    public Task<MemoryStream> DecryptAsync(Stream inputStream, byte[] key, byte[] iv) =>
        TripleDesHelper.DecryptAsync(inputStream, key, iv, _cipherMode, _paddingMode);
}