namespace Zaabee.Cryptography.AsymmetricAlgorithm.RSA;

public static partial class RsaHelper
{
    public static RSAEncryptionPadding Padding { get; set; } = RSAEncryptionPadding.OaepSHA256;

    public static (RSAParameters privateKey, RSAParameters publicKey) GenerateParameters()
    {
        using var rsa = System.Security.Cryptography.RSA.Create();
        var privateKey = rsa.ExportParameters(true);
        var publicKey = rsa.ExportParameters(false);
        return (privateKey, publicKey);
    }

#if !NETSTANDARD2_0
    public static (byte[] privateKey, byte[] publicKey) GenerateKeys()
    {
        using var rsa = System.Security.Cryptography.RSA.Create();
        var privateKey = rsa.ExportRSAPrivateKey();
        var publicKey = rsa.ExportRSAPublicKey();
        return (privateKey, publicKey);
    }
#endif
}