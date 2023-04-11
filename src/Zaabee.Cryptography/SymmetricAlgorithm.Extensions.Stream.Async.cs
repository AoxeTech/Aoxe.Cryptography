namespace Zaabee.Cryptography;

public static partial class SymmetricAlgorithmExtensions
{
    public static async Task EncryptAsync(
        this System.Security.Cryptography.SymmetricAlgorithm symmetricAlgorithm,
        Stream original,
        Stream encrypted,
        byte[]? key = null,
        byte[]? vector = null,
        CipherMode cipherMode = SymmetricAlgorithmHelper.DefaultCipherMode,
        PaddingMode paddingMode = SymmetricAlgorithmHelper.DefaultPaddingMode,
        CancellationToken cancellationToken = default)
    {
        symmetricAlgorithm.Mode = cipherMode;
        symmetricAlgorithm.Padding = paddingMode;
        using (var encryptor = key is not null && vector is not null
                   ? symmetricAlgorithm.CreateEncryptor(key, vector)
                   : symmetricAlgorithm.CreateEncryptor())
        {
#if NETSTANDARD2_0
            var ms = new MemoryStream();
            using (var cryptoStream = new CryptoStream(ms, encryptor, CryptoStreamMode.Write))
            {
                await original.CopyToAsync(cryptoStream, 81920, cancellationToken);
                cryptoStream.FlushFinalBlock();
                ms.Seek(0, SeekOrigin.Begin);
                await ms.CopyToAsync(encrypted, 81920, cancellationToken);
            }
#else
            await using (var cryptoStream = new CryptoStream(encrypted, encryptor, CryptoStreamMode.Write, true))
                await original.CopyToAsync(cryptoStream, cancellationToken);
#endif
        }
        original.TrySeek(0, SeekOrigin.Begin);
        encrypted.TrySeek(0, SeekOrigin.Begin);
    }

    public static async Task DecryptAsync(
        this System.Security.Cryptography.SymmetricAlgorithm symmetricAlgorithm,
        Stream encrypted,
        Stream decrypted,
        byte[]? key = null,
        byte[]? vector = null,
        CipherMode cipherMode = SymmetricAlgorithmHelper.DefaultCipherMode,
        PaddingMode paddingMode = SymmetricAlgorithmHelper.DefaultPaddingMode,
        CancellationToken cancellationToken = default)
    {
        symmetricAlgorithm.Mode = cipherMode;
        symmetricAlgorithm.Padding = paddingMode;
        using (var decryptor = key is not null && vector is not null
                   ? symmetricAlgorithm.CreateDecryptor(key, vector)
                   : symmetricAlgorithm.CreateDecryptor())
        {
#if NETSTANDARD2_0
            var ms = new MemoryStream();
            await encrypted.CopyToAsync(ms);
            ms.Seek(0, SeekOrigin.Begin);
            using (var csDecrypt = new CryptoStream(ms, decryptor, CryptoStreamMode.Read))
                await csDecrypt.CopyToAsync(decrypted, 81920, cancellationToken);
#else
            await using (var csDecrypt = new CryptoStream(encrypted, decryptor, CryptoStreamMode.Read, true))
                await csDecrypt.CopyToAsync(decrypted, cancellationToken);
#endif
        }
        encrypted.TrySeek(0, SeekOrigin.Begin);
        decrypted.TrySeek(0, SeekOrigin.Begin);
    }
}