namespace Zaabee.Cryptography.DES;

public static partial class DesHelper
{
    public static async Task<MemoryStream> EncryptAsync(
        Stream original,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7,
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
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7,
        CancellationToken cancellationToken = default)
    {
        using (var des = System.Security.Cryptography.DES.Create())
        {
            des.Mode = cipherMode;
            des.Padding = paddingMode;
            using (var encryptor = des.CreateEncryptor(key, vector))
#if NET48
            using (var csEncrypt = new CryptoStream(encrypted, encryptor, CryptoStreamMode.Write, true))
                await original.CopyToAsync(csEncrypt, 81920, cancellationToken);
#else
            await using (var csEncrypt = new CryptoStream(encrypted, encryptor, CryptoStreamMode.Write, true))
                await original.CopyToAsync(csEncrypt, cancellationToken);
#endif
        }
        original.TrySeek(0, SeekOrigin.Begin);
        encrypted.TrySeek(0, SeekOrigin.Begin);
    }

    public static async Task<MemoryStream> DecryptAsync(
        Stream encrypted,
        byte[] key,
        byte[] vector,
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7,
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
        CipherMode cipherMode = CipherMode.CBC,
        PaddingMode paddingMode = PaddingMode.PKCS7,
        CancellationToken cancellationToken = default)
    {
        using (var des = System.Security.Cryptography.DES.Create())
        {
            des.Mode = cipherMode;
            des.Padding = paddingMode;
            using (var decryptor = des.CreateDecryptor(key, vector))
#if NET48
            using (var csDecrypt = new CryptoStream(encrypted, decryptor, CryptoStreamMode.Read, true))
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