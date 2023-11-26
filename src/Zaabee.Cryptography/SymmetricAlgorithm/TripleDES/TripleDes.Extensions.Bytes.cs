namespace Zaabee.Cryptography.SymmetricAlgorithm.TripleDES;

public static partial class TripleDesExtensions
{
    public static byte[] EncryptByTripleDes(
        this byte[] original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => TripleDesHelper.Encrypt(original, key, vector, cipherMode, paddingMode);

    public static byte[] DecryptByTripleDes(
        this byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => TripleDesHelper.Decrypt(encrypted, key, vector, cipherMode, paddingMode);
}
