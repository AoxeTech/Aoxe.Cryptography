namespace Zaabee.Cryptography.TripleDES;

public static partial class TripleDesHelper
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
        using var tripleDes = System.Security.Cryptography.TripleDES.Create();
        tripleDes.Encrypt(original, encrypted, key, vector, cipherMode, paddingMode);
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
        using var tripleDes = System.Security.Cryptography.TripleDES.Create();
        tripleDes.Decrypt(encrypted, decrypted, key, vector, cipherMode, paddingMode);
    }
}