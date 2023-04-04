namespace Zaabee.Cryptography.DES;

public static partial class DesExtensions
{
    public static Task EncryptByDesAsync(
        this Stream original,
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        DesHelper.EncryptAsync(original, encrypted, key, vector, cipherMode, paddingMode);

    public static Task DecryptByDesAsync(
        this Stream encrypted,
        Stream decrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        DesHelper.DecryptAsync(encrypted, decrypted, key, vector, cipherMode, paddingMode);

    public static Task<MemoryStream> EncryptByDesAsync(
        this Stream original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        DesHelper.EncryptAsync(original, key, vector, cipherMode, paddingMode);

    public static Task<MemoryStream> DecryptByDesAsync(
        this Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        DesHelper.DecryptAsync(encrypted, key, vector, cipherMode, paddingMode);
}