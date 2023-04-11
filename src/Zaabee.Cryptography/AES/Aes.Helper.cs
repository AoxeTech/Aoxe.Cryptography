namespace Zaabee.Cryptography.AES;

public static partial class AesHelper
{
    public static byte[] GenerateKey()
    {
        using var aes = Aes.Create();
        return SymmetricAlgorithmHelper.GenerateKey(aes);
    }

    public static byte[] GenerateVector()
    {
        using var aes = Aes.Create();
        return SymmetricAlgorithmHelper.GenerateVector(aes);
    }

    public static (byte[] key, byte[] vector) GenerateKeyAndVector()
    {
        using var aes = Aes.Create();
        return SymmetricAlgorithmHelper.GenerateKeyAndVector(aes);
    }
}