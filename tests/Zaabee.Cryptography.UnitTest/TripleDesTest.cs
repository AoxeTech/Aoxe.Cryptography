namespace Zaabee.Cryptography.UnitTest;

public class TripleDesTest
{
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
    public void TripleDesBytesTest(string original)
    {
        var originalBytes = Encoding.UTF8.GetBytes(original);
        var (key, vector) = TripleDesHelper.GenerateKeyAndVector();
        var encrypt = originalBytes.EncryptByTripleDes(key, vector);
        var decrypt = encrypt.DecryptByTripleDes(key, vector);
        var decryptString = Encoding.UTF8.GetString(decrypt);
        Assert.Equal(original, decryptString);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void TripleDesStreamTest1(string original)
    {
        var originalStream = original.GetUtf8Bytes().ToMemoryStream();
        var (key, vector) = TripleDesHelper.GenerateKeyAndVector();
        var encryptStream = originalStream.EncryptByTripleDes(key, vector);
        var decryptStream = encryptStream.DecryptByTripleDes(key, vector);
        var decryptString = decryptStream.ReadToEnd().GetStringByUtf8();
        Assert.Equal(original, decryptString);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public async Task TripleDesStreamAsyncTest1(string original)
    {
        var originalStream = original.GetUtf8Bytes().ToMemoryStream();
        var (key, vector) = TripleDesHelper.GenerateKeyAndVector();
        var encryptStream = await originalStream.EncryptByTripleDesAsync(key, vector);
        var decryptStream = await encryptStream.DecryptByTripleDesAsync(key, vector);
        var decryptString = (await decryptStream.ReadToEndAsync()).GetStringByUtf8();
        Assert.Equal(original, decryptString);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void TripleDesStreamTest2(string original)
    {
        var originalStream = original.GetUtf8Bytes().ToMemoryStream();
        var (key, vector) = TripleDesHelper.GenerateKeyAndVector();
        var encryptStream = new MemoryStream();
        var decryptStream = new MemoryStream();
        originalStream.EncryptByTripleDes(encryptStream, key, vector);
        encryptStream.DecryptByTripleDes(decryptStream, key, vector);
        var decryptString = decryptStream.ReadToEnd().GetStringByUtf8();
        Assert.Equal(original, decryptString);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public async Task TripleDesStreamAsyncTest2(string original)
    {
        var originalStream = original.GetUtf8Bytes().ToMemoryStream();
        var (key, vector) = TripleDesHelper.GenerateKeyAndVector();
        var encryptStream = new MemoryStream();
        var decryptStream = new MemoryStream();
        await originalStream.EncryptByTripleDesAsync(encryptStream, key, vector);
        await encryptStream.DecryptByTripleDesAsync(decryptStream, key, vector);
        var decryptString = (await decryptStream.ReadToEndAsync()).GetStringByUtf8();
        Assert.Equal(original, decryptString);
    }
}