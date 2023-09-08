namespace Zaabee.Cryptography.SymmetricAlgorithm.RC2;

public class Rc2Algorithm : ISymmetricAlgorithm
{
    private readonly CipherMode _cipherMode;
    private readonly PaddingMode _paddingMode;

    public Rc2Algorithm(PaddingMode paddingMode = PaddingMode.PKCS7, CipherMode cipherMode = CipherMode.CBC)
    {
        _paddingMode = paddingMode;
        _cipherMode = cipherMode;
    }

    public byte[] Encrypt(byte[] bytes, byte[] key, byte[] iv) =>
        Rc2Helper.Encrypt(bytes, key, iv, _cipherMode, _paddingMode);

    public MemoryStream Encrypt(Stream inputStream, byte[] key, byte[] iv) =>
        Rc2Helper.Encrypt(inputStream, key, iv, _cipherMode, _paddingMode);

    public Task<MemoryStream> EncryptAsync(Stream inputStream, byte[] key, byte[] iv) =>
        Rc2Helper.EncryptAsync(inputStream, key, iv, _cipherMode, _paddingMode);

    public byte[] Decrypt(byte[] bytes, byte[] key, byte[] iv) =>
        Rc2Helper.Decrypt(bytes, key, iv, _cipherMode, _paddingMode);

    public MemoryStream Decrypt(Stream inputStream, byte[] key, byte[] iv) =>
        Rc2Helper.Decrypt(inputStream, key, iv, _cipherMode, _paddingMode);

    public Task<MemoryStream> DecryptAsync(Stream inputStream, byte[] key, byte[] iv) =>
        Rc2Helper.DecryptAsync(inputStream, key, iv, _cipherMode, _paddingMode);
}