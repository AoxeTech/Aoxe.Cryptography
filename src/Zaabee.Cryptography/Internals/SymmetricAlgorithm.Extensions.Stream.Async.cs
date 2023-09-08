namespace Zaabee.Cryptography.Internals;

internal static partial class SymmetricAlgorithmExtensions
{
    internal static async ValueTask EncryptAsync(
        this Stream original,
        System.Security.Cryptography.SymmetricAlgorithm symmetricAlgorithm,
        Stream encrypted,
        byte[]? key = null,
        byte[]? vector = null,
        CipherMode cipherMode = CommonSettings.DefaultCipherMode,
        PaddingMode paddingMode = CommonSettings.DefaultPaddingMode,
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

    internal static async ValueTask DecryptAsync(
        this Stream encrypted,
        System.Security.Cryptography.SymmetricAlgorithm symmetricAlgorithm,
        Stream decrypted,
        byte[]? key = null,
        byte[]? vector = null,
        CipherMode cipherMode = CommonSettings.DefaultCipherMode,
        PaddingMode paddingMode = CommonSettings.DefaultPaddingMode,
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