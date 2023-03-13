namespace Zaabee.Cryptography.UnitTest;

public class AesTest
{
    [Fact]
    public void DefaultEncodingTest()
    {
        AesHelper.Encoding = Encoding.UTF8;
        Assert.Equal(Encoding.UTF8, AesHelper.Encoding);
    }

    [Fact]
    public void GenerateKeyTest()
    {
        var key0 = AesHelper.GenerateKey();
        var key1 = AesHelper.GenerateKey();
        Assert.NotEqual(key0, key1);
    }

    [Fact]
    public void GenerateVectorTest()
    {
        var vector0 = AesHelper.GenerateVector();
        var vector1 = AesHelper.GenerateVector();
        Assert.NotEqual(vector0, vector1);
    }

    [Fact]
    public void GenerateKeyAndVectorTest()
    {
        var (key0, vector0) = AesHelper.GenerateKeyAndVector();
        var (key1, vector1) = AesHelper.GenerateKeyAndVector();
        Assert.NotEqual(key0, key1);
        Assert.NotEqual(vector0, vector1);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void AesStringTest(string original)
    {
        var (key, vector) = AesHelper.GenerateKeyAndVector();
        var encrypt = original.EncryptByAes(key, vector);
        var decrypt = encrypt.DecryptToStringByAes(key, vector);
        Assert.Equal(original, decrypt);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void AesBytesTest(string original)
    {
        var originalBytes = Encoding.UTF8.GetBytes(original);
        var (key, vector) = AesHelper.GenerateKeyAndVector();
        var encrypt = originalBytes.EncryptByAes(key, vector);
        var decrypt = encrypt.DecryptToBytesByAes(key, vector);
        var decryptString = Encoding.UTF8.GetString(decrypt);
        Assert.Equal(original, decryptString);
    }
}