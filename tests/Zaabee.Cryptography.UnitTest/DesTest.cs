namespace Zaabee.Cryptography.UnitTest;

public class DesTest
{
    [Fact]
    public void EncodingTest()
    {
        DesHelper.Encoding = Encoding.UTF8;
        Assert.Equal(DesHelper.Encoding, Encoding.UTF8);
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
    [InlineData("Here is some data to encrypt!", "Here is the key.", "Here is the vector.")]
    public void DesStringTest(string original, string key, string vector)
    {
        var encrypt = original.EncryptByDes(key, vector);
        var decrypt = encrypt.DecryptByDes(key, vector);
        Assert.Equal(original, decrypt);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!", "Here is the key.", "Here is the vector.")]
    [InlineData("Here is some data to encrypt!", null, "Here is the vector.")]
    [InlineData("Here is some data to encrypt!", "Here is the key.", null)]
    [InlineData("Here is some data to encrypt!", null, null)]
    public void DesBytesTest(string original, string? key, string? vector)
    {
        var bKey = key is null ? DesHelper.GenerateKey() : DesHelper.Encoding.GetBytes(key);
        var bVector = vector is null ? DesHelper.GenerateVector() : DesHelper.Encoding.GetBytes(vector);
        var encrypt = original.EncryptByDes(bKey, bVector);
        var decrypt = encrypt.DecryptByDes(bKey, bVector);
        Assert.Equal(original, decrypt);
    }
}