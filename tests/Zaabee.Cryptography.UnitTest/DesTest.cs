namespace Zaabee.Cryptography.UnitTest;

public class DesTest
{
    [Fact]
    public void DefaultEncodingTest()
    {
        DesHelper.Encoding = Encoding.UTF8;
        Assert.Equal(Encoding.UTF8, DesHelper.Encoding);
    }

    [Fact]
    public void GenerateKeyTest()
    {
        var key0 = DesHelper.GenerateKey();
        var key1 = DesHelper.GenerateKey();
        Assert.NotEqual(key0, key1);
    }

    [Fact]
    public void GenerateVectorTest()
    {
        var vector0 = DesHelper.GenerateVector();
        var vector1 = DesHelper.GenerateVector();
        Assert.NotEqual(vector0, vector1);
    }

    [Fact]
    public void GenerateKeyAndVectorTest()
    {
        var (key0, vector0) = DesHelper.GenerateKeyAndVector();
        var (key1, vector1) = DesHelper.GenerateKeyAndVector();
        Assert.NotEqual(key0, key1);
        Assert.NotEqual(vector0, vector1);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void DesStringTest(string original)
    {
        var (key, vector) = DesHelper.GenerateKeyAndVector();
        var encrypt = original.EncryptByDes(key, vector);
        var decrypt = encrypt.DecryptToStringByDes(key, vector);
        Assert.Equal(original, decrypt);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void DesBytesTest(string original)
    {
        var originalBytes = Encoding.UTF8.GetBytes(original);
        var (key, vector) = DesHelper.GenerateKeyAndVector();
        var encrypt = originalBytes.EncryptByDes(key, vector);
        var decrypt = encrypt.DecryptByDes(key, vector);
        var decryptString = Encoding.UTF8.GetString(decrypt);
        Assert.Equal(original, decryptString);
    }
}