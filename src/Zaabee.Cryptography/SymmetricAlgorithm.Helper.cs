namespace Zaabee.Cryptography;

public static class SymmetricAlgorithmHelper
{
    public const CipherMode DefaultCipherMode = CipherMode.CBC;
    public const PaddingMode DefaultPaddingMode = PaddingMode.PKCS7;

    public static byte[] GenerateKey(System.Security.Cryptography.SymmetricAlgorithm symmetricAlgorithm)
    {
        symmetricAlgorithm.GenerateKey();
        return symmetricAlgorithm.Key;
    }

    public static byte[] GenerateVector(System.Security.Cryptography.SymmetricAlgorithm symmetricAlgorithm)
    {
        symmetricAlgorithm.GenerateIV();
        return symmetricAlgorithm.IV;
    }

    public static (byte[] key, byte[] vector) GenerateKeyAndVector(
        System.Security.Cryptography.SymmetricAlgorithm symmetricAlgorithm)
    {
        symmetricAlgorithm.GenerateKey();
        symmetricAlgorithm.GenerateIV();
        return (symmetricAlgorithm.Key, symmetricAlgorithm.IV);
    }
}