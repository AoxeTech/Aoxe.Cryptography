namespace Zaabee.Cryptography.UnitTest;

public class AesTest
{
    [Fact]
    public void GenerateKeyTest()
    {
        var key0 = AES.AesHelper.GenerateKey();
        var key1 = AES.AesHelper.GenerateKey();
        Assert.NotEqual(key0, key1);
    }

    [Fact]
    public void GenerateVectorTest()
    {
        var vector0 = AES.AesHelper.GenerateVector();
        var vector1 = AES.AesHelper.GenerateVector();
        Assert.NotEqual(vector0, vector1);
    }

    [Fact]
    public void GenerateKeyAndVectorTest()
    {
        var (key0, vector0) = AES.AesHelper.GenerateKeyAndVector();
        var (key1, vector1) = AES.AesHelper.GenerateKeyAndVector();
        Assert.NotEqual(key0, key1);
        Assert.NotEqual(vector0, vector1);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void AesBytesTest(string original)
    {
        var originalBytes = Encoding.UTF8.GetBytes(original);
        var (key, vector) = AES.AesHelper.GenerateKeyAndVector();
        var encrypt = originalBytes.EncryptByAes(key, vector);
        var decrypt = encrypt.DecryptByAes(key, vector);
        var decryptString = Encoding.UTF8.GetString(decrypt);
        Assert.Equal(original, decryptString);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void AesStreamTest(string original)
    {
        var originalStream = original.GetUtf8Bytes().ToMemoryStream();
        var (key, vector) = AES.AesHelper.GenerateKeyAndVector();
        var encryptStream = originalStream.EncryptByAes(key, vector);
        var decryptStream = encryptStream.DecryptByAes(key, vector);
        var decryptString = decryptStream.ReadToEnd().GetStringByUtf8();
        Assert.Equal(original, decryptString);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public async Task AesStreamAsyncTest(string original)
    {
        var originalStream = original.GetUtf8Bytes().ToMemoryStream();
        var (key, vector) = AES.AesHelper.GenerateKeyAndVector();
        var encryptStream = await originalStream.EncryptByAesAsync(key, vector);
        var decryptStream = await encryptStream.DecryptByAesAsync(key, vector);
        var decryptString = (await decryptStream.ReadToEndAsync()).GetStringByUtf8();
        Assert.Equal(original, decryptString);
    }
}