namespace Zaabee.Cryptography.SymmetricAlgorithm.RC2;

public static partial class Rc2Extensions
{
    public static ValueTask EncryptByRc2Async(
        this Stream original,
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => Rc2Helper.EncryptAsync(original, encrypted, key, vector, cipherMode, paddingMode);

    public static ValueTask DecryptByRc2Async(
        this Stream encrypted,
        Stream decrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => Rc2Helper.DecryptAsync(encrypted, decrypted, key, vector, cipherMode, paddingMode);

    public static ValueTask<MemoryStream> EncryptByRc2Async(
        this Stream original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => Rc2Helper.EncryptAsync(original, key, vector, cipherMode, paddingMode);

    public static ValueTask<MemoryStream> DecryptByRc2Async(
        this Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7
    ) => Rc2Helper.DecryptAsync(encrypted, key, vector, cipherMode, paddingMode);
}
