namespace Zaabee.Cryptography.UnitTest;

public class Rc2Test
{
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
    public void Rc2BytesTest(string original)
    {
        var originalBytes = Encoding.UTF8.GetBytes(original);
        var (key, vector) = Rc2Helper.GenerateKeyAndVector();
        var encrypt = originalBytes.EncryptByRc2(key, vector);
        var decrypt = encrypt.DecryptByRc2(key, vector);
        var decryptString = Encoding.UTF8.GetString(decrypt);
        Assert.Equal(original, decryptString);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void Rc2StreamTest1(string original)
    {
        var originalStream = original.GetUtf8Bytes().ToMemoryStream();
        var (key, vector) = Rc2Helper.GenerateKeyAndVector();
        var encryptStream = originalStream.EncryptByRc2(key, vector);
        var decryptStream = encryptStream.DecryptByRc2(key, vector);
        var decryptString = decryptStream.ReadToEnd().GetStringByUtf8();
        Assert.Equal(original, decryptString);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public async Task Rc2StreamAsyncTest1(string original)
    {
        var originalStream = original.GetUtf8Bytes().ToMemoryStream();
        var (key, vector) = Rc2Helper.GenerateKeyAndVector();
        var encryptStream = await originalStream.EncryptByRc2Async(key, vector);
        var decryptStream = await encryptStream.DecryptByRc2Async(key, vector);
        var decryptString = (await decryptStream.ReadToEndAsync()).GetStringByUtf8();
        Assert.Equal(original, decryptString);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void Rc2StreamTest2(string original)
    {
        var originalStream = original.GetUtf8Bytes().ToMemoryStream();
        var (key, vector) = Rc2Helper.GenerateKeyAndVector();
        var encryptStream = new MemoryStream();
        var decryptStream = new MemoryStream();
        originalStream.EncryptByRc2(encryptStream, key, vector);
        encryptStream.DecryptByRc2(decryptStream, key, vector);
        var decryptString = decryptStream.ReadToEnd().GetStringByUtf8();
        Assert.Equal(original, decryptString);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public async Task Rc2StreamAsyncTest2(string original)
    {
        var originalStream = original.GetUtf8Bytes().ToMemoryStream();
        var (key, vector) = Rc2Helper.GenerateKeyAndVector();
        var encryptStream = new MemoryStream();
        var decryptStream = new MemoryStream();
        await originalStream.EncryptByRc2Async(encryptStream, key, vector);
        await encryptStream.DecryptByRc2Async(decryptStream, key, vector);
        var decryptString = (await decryptStream.ReadToEndAsync()).GetStringByUtf8();
        Assert.Equal(original, decryptString);
    }
}
