namespace Zaabee.Cryptography.SymmetricAlgorithm.RC2;

public static partial class Rc2Helper
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
        using var rc2 = System.Security.Cryptography.RC2.Create();
        await original.EncryptAsync(
            rc2,
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
        using var rc2 = System.Security.Cryptography.RC2.Create();
        await encrypted.DecryptAsync(
            rc2,
            decrypted,
            key,
            vector,
            cipherMode,
            paddingMode,
            cancellationToken
        );
    }
}
