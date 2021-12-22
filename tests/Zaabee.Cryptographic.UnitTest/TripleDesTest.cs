namespace Zaabee.Cryptographic.UnitTest;

public class TripleDesTest
{
    [Fact]
    public void EncodingTest()
    {
        TripleDesHelper.Encoding = Encoding.UTF8;
        Assert.Equal(TripleDesHelper.Encoding, Encoding.UTF8);
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
    [InlineData("Here is some data to encrypt!", "Here is the key.", "Here is the vector.")]
    public void TripleDesStringTest(string original, string key, string vector)
    {
        var encrypt = original.EncryptByTripleDes(key, vector);
        var decrypt = encrypt.DecryptByTripleDes(key, vector);
        Assert.Equal(original, decrypt);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!", "Here is the key.", "Here is the vector.")]
    [InlineData("Here is some data to encrypt!", null, "Here is the vector.")]
    [InlineData("Here is some data to encrypt!", "Here is the key.", null)]
    [InlineData("Here is some data to encrypt!", null, null)]
    public void TripleDesBytesTest(string original, string? key, string? vector)
    {
        var bKey = key is null ? TripleDesHelper.GenerateKey() : TripleDesHelper.Encoding.GetBytes(key);
        var bVector = vector is null ? TripleDesHelper.GenerateVector() : TripleDesHelper.Encoding.GetBytes(vector);
        var encrypt = original.EncryptByTripleDes(bKey, bVector);
        var decrypt = encrypt.DecryptByTripleDes(bKey, bVector);
        Assert.Equal(original, decrypt);
    }
}