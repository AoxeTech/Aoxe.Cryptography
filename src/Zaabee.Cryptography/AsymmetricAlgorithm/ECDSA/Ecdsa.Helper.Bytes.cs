namespace Zaabee.Cryptography.AsymmetricAlgorithm.ECDSA;

public static partial class EcdsaHelper
{
    public static byte[] SignData(
        byte[] original,
        ECParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null)
    {
        using var ecDsa = ECDsa.Create();
        ecDsa.ImportParameters(privateKey);
        return ecDsa.SignData(original, hashAlgorithmName ?? CommonSettings.DefaultHashAlgorithmName);
    }

    public static bool VerifyData(
        byte[] original,
        byte[] signature,
        ECParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null)
    {
        using var ecDsa = ECDsa.Create();
        ecDsa.ImportParameters(publicKey);
        return ecDsa.VerifyData(original, signature, hashAlgorithmName ?? CommonSettings.DefaultHashAlgorithmName);
    }

    public static byte[] SignHash(
        byte[] original,
        ECParameters privateKey)
    {
        using var ecDsa = ECDsa.Create();
        ecDsa.ImportParameters(privateKey);
        return ecDsa.SignHash(original);
    }

    public static bool VerifyHash(
        byte[] original,
        byte[] signature,
        ECParameters publicKey)
    {
        using var ecDsa = ECDsa.Create();
        ecDsa.ImportParameters(publicKey);
        return ecDsa.VerifyHash(original, signature);
    }
}