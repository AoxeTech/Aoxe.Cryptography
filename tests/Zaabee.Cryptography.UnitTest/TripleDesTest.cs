namespace Zaabee.Cryptography.UnitTest;

public class TripleDesTest
{
    [Fact]
    public void DefaultEncodingTest()
    {
        TripleDesHelper.Encoding = Encoding.UTF8;
        Assert.Equal(Encoding.UTF8, TripleDesHelper.Encoding);
    }

    [Fact]
    public void GenerateKeyTest()
    {
        var key0 = TripleDesHelper.GenerateKey();
        var key1 = TripleDesHelper.GenerateKey();
        Assert.NotEqual(key0, key1);
    }

    [Fact]
    public void GenerateVectorTest()
    {
        var vector0 = TripleDesHelper.GenerateVector();
        var vector1 = TripleDesHelper.GenerateVector();
        Assert.NotEqual(vector0, vector1);
    }

    [Fact]
    public void GenerateKeyAndVectorTest()
    {
        var (key0, vector0) = TripleDesHelper.GenerateKeyAndVector();
        var (key1, vector1) = TripleDesHelper.GenerateKeyAndVector();
        Assert.NotEqual(key0, key1);
        Assert.NotEqual(vector0, vector1);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void TripleDesStringTest(string original)
    {
        var (key, vector) = TripleDesHelper.GenerateKeyAndVector();
        var encrypt = original.EncryptByTripleDes(key, vector);
        var decrypt = encrypt.DecryptToStringByTripleDes(key, vector);
        Assert.Equal(original, decrypt);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void TripleDesBytesTest(string original)
    {
        var originalBytes = Encoding.UTF8.GetBytes(original);
        var (key, vector) = TripleDesHelper.GenerateKeyAndVector();
        var encrypt = originalBytes.EncryptByTripleDes(key, vector);
        var decrypt = encrypt.DecryptToBytesByTripleDes(key, vector);
        var decryptString = Encoding.UTF8.GetString(decrypt);
        Assert.Equal(original, decryptString);
    }
}