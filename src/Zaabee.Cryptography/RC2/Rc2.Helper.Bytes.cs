namespace Zaabee.Cryptography.RC2;

public static partial class Rc2Helper
{
    public static byte[] Encrypt(
        byte[] original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        using var rc2 = System.Security.Cryptography.RC2.Create();
        return rc2.Encrypt(original, key, vector, cipherMode, paddingMode);
    }

    public static byte[] Decrypt(
        byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7)
    {
        using var rc2 = System.Security.Cryptography.RC2.Create();
        return rc2.Decrypt(encrypted, key, vector, cipherMode, paddingMode);
    }
}