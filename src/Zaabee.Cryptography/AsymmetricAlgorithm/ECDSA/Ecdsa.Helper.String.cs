namespace Zaabee.Cryptography.AsymmetricAlgorithm.ECDSA;

public static partial class EcdsaHelper
{
    public static byte[] SignData(
        string original,
        ECParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        Encoding? encoding = null) =>
        SignData((encoding ?? CommonSettings.DefaultEncoding).GetBytes(original), privateKey, hashAlgorithmName);

    public static bool VerifyData(
        string original,
        byte[] signature,
        ECParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        Encoding? encoding = null) =>
        VerifyData((encoding ?? CommonSettings.DefaultEncoding).GetBytes(original), signature, publicKey,
            hashAlgorithmName);

    public static byte[] SignHash(
        string original,
        ECParameters privateKey,
        Encoding? encoding = null) =>
        SignHash((encoding ?? CommonSettings.DefaultEncoding).GetBytes(original), privateKey);

    public static bool VerifyHash(
        string original,
        byte[] signature,
        ECParameters publicKey,
        Encoding? encoding = null) =>
        VerifyHash((encoding ?? CommonSettings.DefaultEncoding).GetBytes(original), signature, publicKey);
}