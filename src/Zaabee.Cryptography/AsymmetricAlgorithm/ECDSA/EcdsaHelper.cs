namespace Zaabee.Cryptography.AsymmetricAlgorithm.ECDSA;

public static class EcdsaHelper
{
    public static (ECParameters privateKey, ECParameters publicKey) GenerateParameters()
    {
        using var ecDsa = ECDsa.Create();
        var privateKey = ecDsa.ExportParameters(true);
        var publicKey = ecDsa.ExportParameters(false);
        return (privateKey, publicKey);
    }

    #region Data

    public static byte[] SignData(
        string original,
        ECParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        Encoding? encoding = null) =>
        SignData((encoding ?? CommonSettings.DefaultEncoding).GetBytes(original), privateKey, hashAlgorithmName);

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
        string original,
        byte[] signature,
        ECParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        Encoding? encoding = null) =>
        VerifyData((encoding ?? CommonSettings.DefaultEncoding).GetBytes(original), signature, publicKey,
            hashAlgorithmName);

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

    #endregion

    #region Hash

    public static byte[] SignHash(
        string original,
        ECParameters privateKey,
        Encoding? encoding = null) =>
        SignHash((encoding ?? CommonSettings.DefaultEncoding).GetBytes(original), privateKey);

    public static byte[] SignHash(
        byte[] original,
        ECParameters privateKey)
    {
        using var ecDsa = ECDsa.Create();
        ecDsa.ImportParameters(privateKey);
        return ecDsa.SignHash(original);
    }

    public static bool VerifyHash(
        string original,
        byte[] signature,
        ECParameters publicKey,
        Encoding? encoding = null) =>
        VerifyHash((encoding ?? CommonSettings.DefaultEncoding).GetBytes(original), signature, publicKey);

    public static bool VerifyHash(
        byte[] original,
        byte[] signature,
        ECParameters publicKey)
    {
        using var ecDsa = ECDsa.Create();
        ecDsa.ImportParameters(publicKey);
        return ecDsa.VerifyHash(original, signature);
    }

    #endregion
}