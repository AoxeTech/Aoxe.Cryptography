namespace Zaabee.Cryptography.AsymmetricAlgorithm.ECDSA;

public static partial class EcdsaHelper
{
    public static byte[] SignData(
        string data,
        ECParameters privateKey,
        HashAlgorithmName? hashAlgorithmName = null,
        Encoding? encoding = null) =>
        SignData((encoding ?? CommonSettings.DefaultEncoding).GetBytes(data), privateKey, hashAlgorithmName);

    public static bool VerifyData(
        string data,
        byte[] signature,
        ECParameters publicKey,
        HashAlgorithmName? hashAlgorithmName = null,
        Encoding? encoding = null) =>
        VerifyData((encoding ?? CommonSettings.DefaultEncoding).GetBytes(data), signature, publicKey,
            hashAlgorithmName);

    public static byte[] SignHash(
        string hash,
        ECParameters privateKey,
        Encoding? encoding = null) =>
        SignHash((encoding ?? CommonSettings.DefaultEncoding).GetBytes(hash), privateKey);

    public static bool VerifyHash(
        string hash,
        byte[] signature,
        ECParameters publicKey,
        Encoding? encoding = null) =>
        VerifyHash((encoding ?? CommonSettings.DefaultEncoding).GetBytes(hash), signature, publicKey);
}