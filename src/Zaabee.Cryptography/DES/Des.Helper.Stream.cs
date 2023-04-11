namespace Zaabee.Cryptography.DES;

public static partial class DesHelper
{
    public static MemoryStream Encrypt(
        Stream original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = SymmetricAlgorithmHelper.DefaultCipherMode,
        PaddingMode paddingMode = SymmetricAlgorithmHelper.DefaultPaddingMode)
    {
        var encrypted = new MemoryStream();
        Encrypt(original, encrypted, key, vector, cipherMode, paddingMode);
        return encrypted;
    }

    public static void Encrypt(
        Stream original,
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = SymmetricAlgorithmHelper.DefaultCipherMode,
        PaddingMode paddingMode = SymmetricAlgorithmHelper.DefaultPaddingMode)
    {
        using (var des = System.Security.Cryptography.DES.Create())
            des.Encrypt(original, encrypted, key, vector, cipherMode, paddingMode);
        original.TrySeek(0, SeekOrigin.Begin);
        encrypted.TrySeek(0, SeekOrigin.Begin);
    }

    public static MemoryStream Decrypt(
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = SymmetricAlgorithmHelper.DefaultCipherMode,
        PaddingMode paddingMode = SymmetricAlgorithmHelper.DefaultPaddingMode)
    {
        var decrypted = new MemoryStream();
        Decrypt(encrypted, decrypted, key, vector, cipherMode, paddingMode);
        return decrypted;
    }

    public static void Decrypt(
        Stream encrypted,
        Stream decrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = SymmetricAlgorithmHelper.DefaultCipherMode,
        PaddingMode paddingMode = SymmetricAlgorithmHelper.DefaultPaddingMode)
    {
        using (var des = System.Security.Cryptography.DES.Create())
        {
            des.Mode = cipherMode;
            des.Padding = paddingMode;
            using (var decryptor = des.CreateDecryptor(key, vector))
            {
#if NETSTANDARD2_0
                var ms = new MemoryStream();
                encrypted.CopyTo(ms);
                ms.Seek(0, SeekOrigin.Begin);
                using (var csDecrypt = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                    csDecrypt.CopyTo(decrypted);
#else
                using (var csDecrypt = new CryptoStream(encrypted, decryptor, CryptoStreamMode.Read, true))
                    csDecrypt.CopyTo(decrypted);
#endif
            }
        }
        encrypted.TrySeek(0, SeekOrigin.Begin);
        decrypted.TrySeek(0, SeekOrigin.Begin);
    }
}