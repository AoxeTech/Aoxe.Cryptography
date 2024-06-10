namespace Aoxe.Cryptography.UnitTest;

public class EcDsaTest
{
    [Theory]
    [InlineData("Here is some data to encrypt!", "MD5")]
    [InlineData("Here is some data to encrypt!", "SHA1")]
    [InlineData("Here is some data to encrypt!", "SHA256")]
    [InlineData("Here is some data to encrypt!", "SHA384")]
    [InlineData("Here is some data to encrypt!", "SHA512")]
    public void BytesDataTest(string original, string hashAlgorithmName)
    {
        var hashAlgorithm = GetHashAlgorithmName(hashAlgorithmName);
        var (privateKey, publicKey) = EcdsaHelper.GenerateParameters();
        var originalBytes = original.GetUtf8Bytes();
        var signBytes = originalBytes.SignDataByEcdsa(privateKey, hashAlgorithm);
        Assert.True(originalBytes.VerifyDataByEcdsa(signBytes, publicKey, hashAlgorithm));
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void BytesHashTest(string original)
    {
        var (privateKey, publicKey) = EcdsaHelper.GenerateParameters();
        var originalBytes = original.GetUtf8Bytes();
        var signBytes = originalBytes.SignHashByEcdsa(privateKey);
        Assert.True(originalBytes.VerifyHashByEcdsa(signBytes, publicKey));
    }

    private static HashAlgorithmName GetHashAlgorithmName(string name) =>
        name switch
        {
            "MD5" => HashAlgorithmName.MD5,
            "SHA1" => HashAlgorithmName.SHA1,
            "SHA256" => HashAlgorithmName.SHA256,
            "SHA384" => HashAlgorithmName.SHA384,
            "SHA512" => HashAlgorithmName.SHA512,
            _ => throw new ArgumentOutOfRangeException()
        };
}
