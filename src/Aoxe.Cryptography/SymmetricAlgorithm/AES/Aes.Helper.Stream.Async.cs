namespace Aoxe.Cryptography.SymmetricAlgorithm.AES;

public static partial class AesHelper
{
    public static async ValueTask<MemoryStream> EncryptAsync(
        Stream original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CommonSettings.DefaultCipherMode,
        PaddingMode paddingMode = CommonSettings.DefaultPaddingMode,
        CancellationToken cancellationToken = default
    )
    {
        var encrypted = new MemoryStream();
        await EncryptAsync(
            original,
            encrypted,
            key,
            vector,
            cipherMode,
            paddingMode,
            cancellationToken
        );
        return encrypted;
    }

    public static async ValueTask EncryptAsync(
        Stream original,
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CommonSettings.DefaultCipherMode,
        PaddingMode paddingMode = CommonSettings.DefaultPaddingMode,
        CancellationToken cancellationToken = default
    )
    {
        using var aes = Aes.Create();
        await original.EncryptAsync(
            aes,
            encrypted,
            key,
            vector,
            cipherMode,
            paddingMode,
            cancellationToken
        );
    }

    public static async ValueTask<MemoryStream> DecryptAsync(
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CommonSettings.DefaultCipherMode,
        PaddingMode paddingMode = CommonSettings.DefaultPaddingMode,
        CancellationToken cancellationToken = default
    )
    {
        var decrypted = new MemoryStream();
        await DecryptAsync(
            encrypted,
            decrypted,
            key,
            vector,
            cipherMode,
            paddingMode,
            cancellationToken
        );
        return decrypted;
    }

    public static async ValueTask DecryptAsync(
        Stream encrypted,
        Stream decrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CommonSettings.DefaultCipherMode,
        PaddingMode paddingMode = CommonSettings.DefaultPaddingMode,
        CancellationToken cancellationToken = default
    )
    {
        using var aes = Aes.Create();
        await encrypted.DecryptAsync(
            aes,
            decrypted,
            key,
            vector,
            cipherMode,
            paddingMode,
            cancellationToken
        );
    }
}
