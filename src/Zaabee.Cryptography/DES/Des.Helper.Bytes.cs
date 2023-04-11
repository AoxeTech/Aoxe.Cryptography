namespace Zaabee.Cryptography.DES;

public static partial class DesHelper
{
    public static byte[] Encrypt(
        byte[] original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = SymmetricAlgorithmHelper.DefaultCipherMode,
        PaddingMode paddingMode = SymmetricAlgorithmHelper.DefaultPaddingMode)
    {
        using var des = System.Security.Cryptography.DES.Create();
        return des.Encrypt(original, key, vector, cipherMode, paddingMode);
    }

    public static byte[] Decrypt(
        byte[] encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = SymmetricAlgorithmHelper.DefaultCipherMode,
        PaddingMode paddingMode = SymmetricAlgorithmHelper.DefaultPaddingMode)
    {
        using var des = System.Security.Cryptography.DES.Create();
        des.Mode = cipherMode;
        des.Padding = paddingMode;
        using var msDecrypt = new MemoryStream(encrypted);
        using var decryptor = des.CreateDecryptor(key, vector);
        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        return csDecrypt.ReadToEnd();
    }
}