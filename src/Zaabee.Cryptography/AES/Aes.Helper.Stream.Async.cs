namespace Zaabee.Cryptography.AES;

public static partial class AesHelper
{
    public static async Task<MemoryStream> EncryptAsync(
        Stream original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = SymmetricAlgorithmHelper.DefaultCipherMode,
        PaddingMode paddingMode = SymmetricAlgorithmHelper.DefaultPaddingMode,
        CancellationToken cancellationToken = default)
    {
        var encrypted = new MemoryStream();
        await EncryptAsync(original, encrypted, key, vector, cipherMode, paddingMode, cancellationToken);
        return encrypted;
    }

    public static async Task EncryptAsync(
        Stream original,
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = SymmetricAlgorithmHelper.DefaultCipherMode,
        PaddingMode paddingMode = SymmetricAlgorithmHelper.DefaultPaddingMode,
        CancellationToken cancellationToken = default)
    {
        using var aes = Aes.Create();
        await aes.EncryptAsync(original, encrypted, key, vector, cipherMode, paddingMode, cancellationToken);
    }

    public static async Task<MemoryStream> DecryptAsync(
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = SymmetricAlgorithmHelper.DefaultCipherMode,
        PaddingMode paddingMode = SymmetricAlgorithmHelper.DefaultPaddingMode,
        CancellationToken cancellationToken = default)
    {
        var decrypted = new MemoryStream();
        await DecryptAsync(encrypted, decrypted, key, vector, cipherMode, paddingMode, cancellationToken);
        return decrypted;
    }

    public static async Task DecryptAsync(
        Stream encrypted,
        Stream decrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = SymmetricAlgorithmHelper.DefaultCipherMode,
        PaddingMode paddingMode = SymmetricAlgorithmHelper.DefaultPaddingMode,
        CancellationToken cancellationToken = default)
    {
        using var aes = Aes.Create();
        await aes.DecryptAsync(encrypted, decrypted, key, vector, cipherMode, paddingMode, cancellationToken);
    }
}