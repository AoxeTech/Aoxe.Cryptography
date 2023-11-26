namespace Zaabee.Cryptography.AsymmetricAlgorithm.ECDSA;

public static partial class EcdsaHelper
{
    public static byte[] SignData(
        byte[] data,
        ECParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null
    )
    {
        using var ecDsa = ECDsa.Create();
        ecDsa.ImportParameters(privateKey);
        return ecDsa.SignData(data, hashAlgorithmName ?? CommonSettings.DefaultHashAlgorithmName);
    }

    public static bool VerifyData(
        byte[] data,
        byte[] signature,
        ECParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null
    )
    {
        using var ecDsa = ECDsa.Create();
        ecDsa.ImportParameters(publicKey);
        return ecDsa.VerifyData(
            data,
            signature,
            hashAlgorithmName ?? CommonSettings.DefaultHashAlgorithmName
        );
    }

    public static byte[] SignHash(byte[] hash, ECParameters privateKey)
    {
        using var ecDsa = ECDsa.Create();
        ecDsa.ImportParameters(privateKey);
        return ecDsa.SignHash(hash);
    }

    public static bool VerifyHash(byte[] hash, byte[] signature, ECParameters publicKey)
    {
        using var ecDsa = ECDsa.Create();
        ecDsa.ImportParameters(publicKey);
        return ecDsa.VerifyHash(hash, signature);
    }
}
