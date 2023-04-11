namespace Zaabee.Cryptography;

public static partial class SymmetricAlgorithmExtensions
{
    public static byte[] Encrypt(
        this SymmetricAlgorithm symmetricAlgorithm,
        byte[] original,
        byte[]? key = null,
        byte[]? vector = null,
        CipherMode cipherMode = SymmetricAlgorithmHelper.DefaultCipherMode,
        PaddingMode paddingMode = SymmetricAlgorithmHelper.DefaultPaddingMode)
    {
        symmetricAlgorithm.Mode = cipherMode;
        symmetricAlgorithm.Padding = paddingMode;
        using var msEncrypt = new MemoryStream();
        using (var encryptor = key is not null && vector is not null
                   ? symmetricAlgorithm.CreateEncryptor(key, vector)
                   : symmetricAlgorithm.CreateEncryptor())
        using (var cryptoStream = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
        {
#if NETSTANDARD2_0
            cryptoStream.Write(original, 0, original.Length);
#else
            cryptoStream.Write(original);
#endif
        }
        return msEncrypt.ToArray();
    }

    public static byte[] Decrypt(
        this SymmetricAlgorithm symmetricAlgorithm,
        byte[] encrypted,
        byte[]? key = null,
        byte[]? vector = null,
        CipherMode cipherMode = SymmetricAlgorithmHelper.DefaultCipherMode,
        PaddingMode paddingMode = SymmetricAlgorithmHelper.DefaultPaddingMode)
    {
        symmetricAlgorithm.Mode = cipherMode;
        symmetricAlgorithm.Padding = paddingMode;
        using var msDecrypt = new MemoryStream(encrypted);
        using var decryptor = key is not null && vector is not null
            ? symmetricAlgorithm.CreateDecryptor(key, vector)
            : symmetricAlgorithm.CreateDecryptor();
        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        return csDecrypt.ReadToEnd();
    }
}