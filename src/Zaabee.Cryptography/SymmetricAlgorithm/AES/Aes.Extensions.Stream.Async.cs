namespace Zaabee.Cryptography.SymmetricAlgorithm.AES;

public static partial class AesExtensions
{
    public static ValueTask EncryptByAesAsync(
        this Stream original,
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => AesHelper.EncryptAsync(original, encrypted, key, vector, cipherMode, paddingMode);

    public static ValueTask DecryptByAesAsync(
        this Stream encrypted,
        Stream decrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => AesHelper.DecryptAsync(encrypted, decrypted, key, vector, cipherMode, paddingMode);

    public static ValueTask<MemoryStream> EncryptByAesAsync(
        this Stream original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => AesHelper.EncryptAsync(original, key, vector, cipherMode, paddingMode);

    public static ValueTask<MemoryStream> DecryptByAesAsync(
        this Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => AesHelper.DecryptAsync(encrypted, key, vector, cipherMode, paddingMode);
}
