namespace Zaabee.Cryptography.SymmetricAlgorithm.TripleDES;

public static partial class TripleDesHelper
{
    public static async Task<MemoryStream> EncryptAsync(
        Stream original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CommonSettings.DefaultCipherMode,
        PaddingMode paddingMode = CommonSettings.DefaultPaddingMode,
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
        CipherMode cipherMode = CommonSettings.DefaultCipherMode,
        PaddingMode paddingMode = CommonSettings.DefaultPaddingMode,
        CancellationToken cancellationToken = default)
    {
        using var tripleDes = System.Security.Cryptography.TripleDES.Create();
        await tripleDes.EncryptAsync(original, encrypted, key, vector, cipherMode, paddingMode, cancellationToken);
    }

    public static async Task<MemoryStream> DecryptAsync(
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CommonSettings.DefaultCipherMode,
        PaddingMode paddingMode = CommonSettings.DefaultPaddingMode,
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
        CipherMode cipherMode = CommonSettings.DefaultCipherMode,
        PaddingMode paddingMode = CommonSettings.DefaultPaddingMode,
        CancellationToken cancellationToken = default)
    {
        using var tripleDes = System.Security.Cryptography.TripleDES.Create();
        await tripleDes.DecryptAsync(encrypted, decrypted, key, vector, cipherMode, paddingMode, cancellationToken);
    }
}