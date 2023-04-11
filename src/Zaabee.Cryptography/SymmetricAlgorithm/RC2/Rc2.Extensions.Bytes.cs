namespace Zaabee.Cryptography.SymmetricAlgorithm.RC2;

public static partial class Rc2Extensions
{
    public static byte[] EncryptByRc2(
        this byte[] original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        Rc2Helper.Encrypt(original, key, vector, cipherMode, paddingMode);

    public static byte[] DecryptByRc2(
        this byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7) =>
        Rc2Helper.Decrypt(encrypted, key, vector, cipherMode, paddingMode);
}