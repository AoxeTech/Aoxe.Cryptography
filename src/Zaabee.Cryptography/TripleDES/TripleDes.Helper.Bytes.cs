namespace Zaabee.Cryptography.TripleDES;

public static partial class TripleDesHelper
{
    public static byte[] Encrypt(
        byte[] original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = SymmetricAlgorithmHelper.DefaultCipherMode,
        PaddingMode paddingMode = SymmetricAlgorithmHelper.DefaultPaddingMode)
    {
        using var tripleDes = System.Security.Cryptography.TripleDES.Create();
        return tripleDes.Encrypt(original, key, vector, cipherMode, paddingMode);
    }

    public static byte[] Decrypt(
        byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = SymmetricAlgorithmHelper.DefaultCipherMode,
        PaddingMode paddingMode = SymmetricAlgorithmHelper.DefaultPaddingMode)
    {
        using var tripleDes = System.Security.Cryptography.TripleDES.Create();
        return tripleDes.Decrypt(encrypted, key, vector, cipherMode, paddingMode);
    }
}