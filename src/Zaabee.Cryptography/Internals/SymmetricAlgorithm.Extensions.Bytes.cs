namespace Zaabee.Cryptography.Internals;

internal static partial class SymmetricAlgorithmExtensions
{
    internal static byte[] Encrypt(
        this byte[] original,
        System.Security.Cryptography.SymmetricAlgorithm symmetricAlgorithm,
        byte[]? key = null,
        byte[]? vector = null,
        CipherMode cipherMode = CommonSettings.DefaultCipherMode,
        PaddingMode paddingMode = CommonSettings.DefaultPaddingMode
    )
    {
        symmetricAlgorithm.Mode = cipherMode;
        symmetricAlgorithm.Padding = paddingMode;
        using var msEncrypt = new MemoryStream();
        using (
            var encryptor =
                key is not null && vector is not null
                    ? symmetricAlgorithm.CreateEncryptor(key, vector)
                    : symmetricAlgorithm.CreateEncryptor()
        )
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

    internal static byte[] Decrypt(
        this byte[] encrypted,
        System.Security.Cryptography.SymmetricAlgorithm symmetricAlgorithm,
        byte[]? key = null,
        byte[]? vector = null,
        CipherMode cipherMode = CommonSettings.DefaultCipherMode,
        PaddingMode paddingMode = CommonSettings.DefaultPaddingMode
    )
    {
        symmetricAlgorithm.Mode = cipherMode;
        symmetricAlgorithm.Padding = paddingMode;
        using var msDecrypt = new MemoryStream(encrypted);
        using var decryptor =
            key is not null && vector is not null
                ? symmetricAlgorithm.CreateDecryptor(key, vector)
                : symmetricAlgorithm.CreateDecryptor();
        using var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read);
        return csDecrypt.ReadToEnd();
    }
}
