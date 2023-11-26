namespace Zaabee.Cryptography.SymmetricAlgorithm.AES;

public static partial class AesExtensions
{
    public static byte[] EncryptByAes(
        this byte[] original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => AesHelper.Encrypt(original, key, vector, cipherMode, paddingMode);

    public static byte[] DecryptByAes(
        this byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => AesHelper.Decrypt(encrypted, key, vector, cipherMode, paddingMode);
}
