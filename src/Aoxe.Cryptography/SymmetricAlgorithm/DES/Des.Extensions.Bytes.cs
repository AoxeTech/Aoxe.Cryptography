namespace Aoxe.Cryptography.SymmetricAlgorithm.DES;

public static partial class DesExtensions
{
    public static byte[] EncryptByDes(
        this byte[] original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => DesHelper.Encrypt(original, key, vector, cipherMode, paddingMode);

    public static byte[] DecryptByDes(
        this byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => DesHelper.Decrypt(encrypted, key, vector, cipherMode, paddingMode);
}
