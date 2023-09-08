namespace Zaabee.Cryptography.AsymmetricAlgorithm.DSA;

public static partial class DsaHelper
{
    public static (DSAParameters privateKey, DSAParameters publicKey) GenerateParameters()
    {
        using var dsa = System.Security.Cryptography.DSA.Create();
        var privateKey = dsa.ExportParameters(true);
        var publicKey = dsa.ExportParameters(false);
        return (privateKey, publicKey);
    }

#if !NETSTANDARD2_0
    public static (byte[] privateKey, byte[] publicKey) GenerateKeys()
    {
        using var dsa = System.Security.Cryptography.DSA.Create();
        var privateKey = dsa.ExportPkcs8PrivateKey();
        var publicKey = dsa.ExportSubjectPublicKeyInfo();
        return (privateKey, publicKey);
    }
#endif
}