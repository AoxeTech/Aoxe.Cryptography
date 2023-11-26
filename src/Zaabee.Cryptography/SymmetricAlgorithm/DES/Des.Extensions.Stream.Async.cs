namespace Zaabee.Cryptography.SymmetricAlgorithm.DES;

public static partial class DesExtensions
{
    public static ValueTask EncryptByDesAsync(
        this Stream original,
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => DesHelper.EncryptAsync(original, encrypted, key, vector, cipherMode, paddingMode);

    public static ValueTask DecryptByDesAsync(
        this Stream encrypted,
        Stream decrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => DesHelper.DecryptAsync(encrypted, decrypted, key, vector, cipherMode, paddingMode);

    public static ValueTask<MemoryStream> EncryptByDesAsync(
        this Stream original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => DesHelper.EncryptAsync(original, key, vector, cipherMode, paddingMode);

    public static ValueTask<MemoryStream> DecryptByDesAsync(
        this Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => DesHelper.DecryptAsync(encrypted, key, vector, cipherMode, paddingMode);
}
