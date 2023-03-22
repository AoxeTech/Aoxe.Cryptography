namespace Zaabee.Cryptography.UnitTest;

public class Rc2Test
{
    [Fact]
    public void DefaultEncodingTest()
    {
        Rc2Helper.Encoding = Encoding.UTF8;
        Assert.Equal(Encoding.UTF8, Rc2Helper.Encoding);
    }

    [Fact]
    public void GenerateKeyTest()
    {
        var key0 = Rc2Helper.GenerateKey();
        var key1 = Rc2Helper.GenerateKey();
        Assert.NotEqual(key0, key1);
    }

    [Fact]
    public void GenerateVectorTest()
    {
        var vector0 = Rc2Helper.GenerateVector();
        var vector1 = Rc2Helper.GenerateVector();
        Assert.NotEqual(vector0, vector1);
    }

    [Fact]
    public void GenerateKeyAndVectorTest()
    {
        var (key0, vector0) = Rc2Helper.GenerateKeyAndVector();
        var (key1, vector1) = Rc2Helper.GenerateKeyAndVector();
        Assert.NotEqual(key0, key1);
        Assert.NotEqual(vector0, vector1);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void Rc2StringTest(string original)
    {
        var (key, vector) = Rc2Helper.GenerateKeyAndVector();
        var encrypt = original.EncryptByRc2(key, vector);
        var decrypt = encrypt.DecryptToStringByRc2(key, vector);
        Assert.Equal(original, decrypt);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void Rc2BytesTest(string original)
    {
        var originalBytes = Encoding.UTF8.GetBytes(original);
        var (key, vector) = Rc2Helper.GenerateKeyAndVector();
        var encrypt = originalBytes.EncryptByRc2(key, vector);
        var decrypt = encrypt.DecryptByRc2(key, vector);
        var decryptString = Encoding.UTF8.GetString(decrypt);
        Assert.Equal(original, decryptString);
    }
}