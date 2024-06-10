namespace Aoxe.Cryptography.SymmetricAlgorithm.DES;

public static partial class DesHelper
{
    public static byte[] Encrypt(
        byte[] original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CommonSettings.DefaultCipherMode,
        PaddingMode paddingMode = CommonSettings.DefaultPaddingMode
    )
    {
        using var des = System.Security.Cryptography.DES.Create();
        return original.Encrypt(des, key, vector, cipherMode, paddingMode);
    }

    public static byte[] Decrypt(
        byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CommonSettings.DefaultCipherMode,
        PaddingMode paddingMode = CommonSettings.DefaultPaddingMode
    )
    {
        using var des = System.Security.Cryptography.DES.Create();
        return encrypted.Decrypt(des, key, vector, cipherMode, paddingMode);
    }
}
