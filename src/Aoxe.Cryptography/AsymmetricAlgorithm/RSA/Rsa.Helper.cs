namespace Aoxe.Cryptography.AsymmetricAlgorithm.RSA;

public static partial class RsaHelper
{
    public static (RSAParameters privateKey, RSAParameters publicKey) GenerateParameters()
    {
        using var rsa = System.Security.Cryptography.RSA.Create();
        var privateKey = rsa.ExportParameters(true);
        var publicKey = rsa.ExportParameters(false);
        return (privateKey, publicKey);
    }

    public static (byte[] privateKey, byte[] publicKey) GenerateKeys()
    {
        using var rsa = System.Security.Cryptography.RSA.Create();
#if NETSTANDARD2_0
        var privateKey = SerializeToXmlBytes(rsa.ExportParameters(true));
        var publicKey = SerializeToXmlBytes(rsa.ExportParameters(false));
#else
        var privateKey = rsa.ExportRSAPrivateKey();
        var publicKey = rsa.ExportRSAPublicKey();
#endif
        return (privateKey, publicKey);
    }

#if NETSTANDARD2_0
    private static byte[] SerializeToXmlBytes(RSAParameters parameters)
    {
        var serializer = new XmlSerializer(typeof(RSAParameters));
        using var stringWriter = new StringWriter();
        serializer.Serialize(stringWriter, parameters);
        return stringWriter.ToString().GetUtf8Bytes();
    }

    private static RSAParameters DeserializeFromXmlBytes(this byte[] xmlBytes)
    {
        if (xmlBytes is null || xmlBytes.Length == 0)
            throw new ArgumentException("Input byte array is null or empty.", nameof(xmlBytes));

        var xmlString = Encoding.UTF8.GetString(xmlBytes);
        var serializer = new XmlSerializer(typeof(RSAParameters));
        using var stringReader = new StringReader(xmlString);
        return (RSAParameters)serializer.Deserialize(stringReader)!;
    }
#endif
}
