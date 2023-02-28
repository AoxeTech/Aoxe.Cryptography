namespace Zaabee.Cryptography.UnitTest;

public class EcDsaTest
{
    [Fact]
    public void Test()
    {
        EcdsaHelper.Encoding = Encoding.UTF8;
        EcdsaHelper.HashAlgorithmName = HashAlgorithmName.SHA256;
        Assert.Equal(EcdsaHelper.Encoding, Encoding.UTF8);
        Assert.Equal(EcdsaHelper.HashAlgorithmName, HashAlgorithmName.SHA256);
    }

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
        var originalBytes = EcdsaHelper.Encoding.GetBytes(original);
        var signBytes = originalBytes.SignDataByEcdsa(privateKey, hashAlgorithm);
        Assert.True(originalBytes.VerifyDataByEcdsa(signBytes, publicKey, hashAlgorithm));
    }

    [Theory]
    [InlineData("Here is some data to encrypt!", "MD5")]
    [InlineData("Here is some data to encrypt!", "SHA1")]
    [InlineData("Here is some data to encrypt!", "SHA256")]
    [InlineData("Here is some data to encrypt!", "SHA384")]
    [InlineData("Here is some data to encrypt!", "SHA512")]
    public void StringDataTest(string original, string hashAlgorithmName)
    {
        var hashAlgorithm = GetHashAlgorithmName(hashAlgorithmName);
        var (privateKey, publicKey) = EcdsaHelper.GenerateParameters();
        var signBytes = original.SignDataByEcdsa(privateKey, hashAlgorithm);
        Assert.True(original.VerifyDataByEcdsa(signBytes, publicKey, hashAlgorithm));
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void BytesHashTest(string original)
    {
        var (privateKey, publicKey) = EcdsaHelper.GenerateParameters();
        var originalBytes = EcdsaHelper.Encoding.GetBytes(original);
        var signBytes = originalBytes.SignHashByEcdsa(privateKey);
        Assert.True(originalBytes.VerifyHashByEcdsa(signBytes, publicKey));
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void StringHashTest(string original)
    {
        var (privateKey, publicKey) = EcdsaHelper.GenerateParameters();
        var signBytes = original.SignHashByEcdsa(privateKey);
        Assert.True(original.VerifyHashByEcdsa(signBytes, publicKey));
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