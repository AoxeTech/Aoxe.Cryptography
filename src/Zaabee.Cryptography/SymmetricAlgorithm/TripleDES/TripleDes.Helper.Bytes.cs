namespace Zaabee.Cryptography.SymmetricAlgorithm.TripleDES;

public static partial class TripleDesHelper
{
    public static byte[] Encrypt(
        byte[] original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CommonSettings.DefaultCipherMode,
        PaddingMode paddingMode = CommonSettings.DefaultPaddingMode
    )
    {
        using var tripleDes = System.Security.Cryptography.TripleDES.Create();
        return original.Encrypt(tripleDes, key, vector, cipherMode, paddingMode);
    }

    public static byte[] Decrypt(
        byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CommonSettings.DefaultCipherMode,
        PaddingMode paddingMode = CommonSettings.DefaultPaddingMode
    )
    {
        using var tripleDes = System.Security.Cryptography.TripleDES.Create();
        return encrypted.Decrypt(tripleDes, key, vector, cipherMode, paddingMode);
    }
}
