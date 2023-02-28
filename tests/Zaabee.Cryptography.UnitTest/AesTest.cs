namespace Zaabee.Cryptography.UnitTest;

public class AesTest
{
    [Fact]
    public void EncodingTest()
    {
        AesHelper.Encoding = Encoding.UTF8;
        Assert.Equal(AesHelper.Encoding, Encoding.UTF8);
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
    [InlineData("Here is some data to encrypt!", "Here is the key.", "Here is the vector.")]
    public void AesStringTest(string original, string key, string vector)
    {
        var encrypt = original.EncryptByAes(key, vector);
        var decrypt = encrypt.DecryptByAes(key, vector);
        Assert.Equal(original, decrypt);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!", "Here is the key.", "Here is the vector.")]
    [InlineData("Here is some data to encrypt!", null, "Here is the vector.")]
    [InlineData("Here is some data to encrypt!", "Here is the key.", null)]
    [InlineData("Here is some data to encrypt!", null, null)]
    public void AesBytesTest(string original, string? key, string? vector)
    {
        var bKey = key is null ? AesHelper.GenerateKey() : AesHelper.Encoding.GetBytes(key);
        var bVector = vector is null ? AesHelper.GenerateVector() : AesHelper.Encoding.GetBytes(vector);
        var encrypt = original.EncryptByAes(bKey, bVector);
        var decrypt = encrypt.DecryptByAes(bKey, bVector);
        Assert.Equal(original, decrypt);
    }
}