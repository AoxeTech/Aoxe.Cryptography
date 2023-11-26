namespace Zaabee.Cryptography.SymmetricAlgorithm.RC2;

public static partial class Rc2Extensions
{
    public static void EncryptByRc2(
        this Stream original,
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => Rc2Helper.Encrypt(original, encrypted, key, vector, cipherMode, paddingMode);

    public static void DecryptByRc2(
        this Stream encrypted,
        Stream decrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => Rc2Helper.Decrypt(encrypted, decrypted, key, vector, cipherMode, paddingMode);

    public static MemoryStream EncryptByRc2(
        this Stream original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => Rc2Helper.Encrypt(original, key, vector, cipherMode, paddingMode);

    public static MemoryStream DecryptByRc2(
        this Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => Rc2Helper.Decrypt(encrypted, key, vector, cipherMode, paddingMode);
}
