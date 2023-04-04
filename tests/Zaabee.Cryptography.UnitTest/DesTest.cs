namespace Zaabee.Cryptography.UnitTest;

public class DesTest
{
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
    public void DesBytesTest(string original)
    {
        var originalBytes = Encoding.UTF8.GetBytes(original);
        var (key, vector) = DesHelper.GenerateKeyAndVector();
        var encrypt = originalBytes.EncryptByDes(key, vector);
        var decrypt = encrypt.DecryptByDes(key, vector);
        var decryptString = Encoding.UTF8.GetString(decrypt);
        Assert.Equal(original, decryptString);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void DesStreamTest1(string original)
    {
        var originalStream = original.GetUtf8Bytes().ToMemoryStream();
        var (key, vector) = DesHelper.GenerateKeyAndVector();
        var encryptStream = originalStream.EncryptByDes(key, vector);
        var decryptStream = encryptStream.DecryptByDes(key, vector);
        var decryptString = decryptStream.ReadToEnd().GetStringByUtf8();
        Assert.Equal(original, decryptString);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public async Task DesStreamAsyncTest1(string original)
    {
        var originalStream = original.GetUtf8Bytes().ToMemoryStream();
        var (key, vector) = DesHelper.GenerateKeyAndVector();
        var encryptStream = await originalStream.EncryptByDesAsync(key, vector);
        var decryptStream = await encryptStream.DecryptByDesAsync(key, vector);
        var decryptString = (await decryptStream.ReadToEndAsync()).GetStringByUtf8();
        Assert.Equal(original, decryptString);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void DesStreamTest2(string original)
    {
        var originalStream = original.GetUtf8Bytes().ToMemoryStream();
        var (key, vector) = DesHelper.GenerateKeyAndVector();
        var encryptStream = new MemoryStream();
        var decryptStream = new MemoryStream();
        originalStream.EncryptByDes(encryptStream, key, vector);
        encryptStream.DecryptByDes(decryptStream, key, vector);
        var decryptString = decryptStream.ReadToEnd().GetStringByUtf8();
        Assert.Equal(original, decryptString);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public async Task DesStreamAsyncTest2(string original)
    {
        var originalStream = original.GetUtf8Bytes().ToMemoryStream();
        var (key, vector) = DesHelper.GenerateKeyAndVector();
        var encryptStream = new MemoryStream();
        var decryptStream = new MemoryStream();
        await originalStream.EncryptByDesAsync(encryptStream, key, vector);
        await encryptStream.DecryptByDesAsync(decryptStream, key, vector);
        var decryptString = (await decryptStream.ReadToEndAsync()).GetStringByUtf8();
        Assert.Equal(original, decryptString);
    }
}