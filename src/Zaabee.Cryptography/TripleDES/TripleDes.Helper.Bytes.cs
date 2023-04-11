namespace Zaabee.Cryptography.TripleDES;

public static partial class TripleDesHelper
{
    public static byte[] Encrypt(
        byte[] original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        using var tripleDes = System.Security.Cryptography.TripleDES.Create();
        return tripleDes.Encrypt(original, key, vector, cipherMode, paddingMode);
    }

    public static byte[] Decrypt(
        byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        using var tripleDes = System.Security.Cryptography.TripleDES.Create();
        return tripleDes.Decrypt(encrypted, key, vector, cipherMode, paddingMode);
    }
}