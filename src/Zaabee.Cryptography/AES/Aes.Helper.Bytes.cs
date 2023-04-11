namespace Zaabee.Cryptography.AES;

public static partial class AesHelper
{
    public static byte[] Encrypt(
        byte[] original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        using var aes = Aes.Create();
        return aes.Encrypt(original, key, vector, cipherMode, paddingMode);
    }

    public static byte[] Decrypt(
        byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        using var aes = Aes.Create();
        return aes.Decrypt(encrypted, key, vector, cipherMode, paddingMode);
    }
}