namespace Zaabee.Cryptography.AES;

public static partial class AesHelper
{
    public static MemoryStream Encrypt(
        Stream original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        var encrypted = new MemoryStream();
        Encrypt(original, encrypted, key, vector, cipherMode, paddingMode);
        return encrypted;
    }

    public static void Encrypt(
        Stream original,
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        using (var aes = Aes.Create())
            aes.Encrypt(original, encrypted, key, vector, cipherMode, paddingMode);
        original.TrySeek(0, SeekOrigin.Begin);
        encrypted.TrySeek(0, SeekOrigin.Begin);
    }

    public static MemoryStream Decrypt(
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        var decrypted = new MemoryStream();
        Decrypt(encrypted, decrypted, key, vector, cipherMode, paddingMode);
        return decrypted;
    }

    public static void Decrypt(
        Stream encrypted,
        Stream decrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        using var aes = Aes.Create();
        aes.Decrypt(encrypted, decrypted, key, vector, cipherMode, paddingMode);
    }
}