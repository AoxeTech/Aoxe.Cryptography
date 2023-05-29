namespace Zaabee.Cryptography.UnitTest;

public class RsaTest
{
    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void Pkcs1Test(string original)
    {
        var (privateKey, publicKey) = RsaHelper.GenerateParameters();
        var encryptBytes = original.GetUtf8Bytes().EncryptByRsa(publicKey, RSAEncryptionPadding.Pkcs1);
        var decrypt = encryptBytes.DecryptByRsa(privateKey, RSAEncryptionPadding.Pkcs1).GetStringByUtf8();
        Assert.Equal(original, decrypt);
    }

#if !NET48
    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void OaepSha256Test(string original)
    {
        var (privateKey, publicKey) = RsaHelper.GenerateKeys();
        var encryptBytes = original.GetUtf8Bytes().EncryptByRsa(publicKey, RSAEncryptionPadding.OaepSHA256);
        var decrypt = encryptBytes.DecryptByRsa(privateKey, RSAEncryptionPadding.OaepSHA256).GetStringByUtf8();
        Assert.Equal(original, decrypt);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void OaepSha384Test(string original)
    {
        var (privateKey, publicKey) = RsaHelper.GenerateKeys();
        var encryptBytes = original.GetUtf8Bytes().EncryptByRsa(publicKey, RSAEncryptionPadding.OaepSHA384);
        var decrypt = encryptBytes.DecryptByRsa(privateKey, RSAEncryptionPadding.OaepSHA384).GetStringByUtf8();
        Assert.Equal(original, decrypt);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void OaepSha512Test(string original)
    {
        var (privateKey, publicKey) = RsaHelper.GenerateKeys();
        var encryptBytes = original.GetUtf8Bytes().EncryptByRsa(publicKey, RSAEncryptionPadding.OaepSHA512);
        var decrypt = encryptBytes.DecryptByRsa(privateKey, RSAEncryptionPadding.OaepSHA512).GetStringByUtf8();
        Assert.Equal(original, decrypt);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void Pkcs1WithBytesKeyTest(string original)
    {
        var (privateKey, publicKey) = RsaHelper.GenerateKeys();
        var encryptBytes = original.GetUtf8Bytes().EncryptByRsa(publicKey, RSAEncryptionPadding.Pkcs1);
        var decrypt = encryptBytes.DecryptByRsa(privateKey, RSAEncryptionPadding.Pkcs1).GetStringByUtf8();
        Assert.Equal(original, decrypt);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void OaepSha1WithBytesKeyTest(string original)
    {
        var (privateKey, publicKey) = RsaHelper.GenerateKeys();
        var encryptBytes = original.GetUtf8Bytes().EncryptByRsa(publicKey, RSAEncryptionPadding.OaepSHA1);
        var decrypt = encryptBytes.DecryptByRsa(privateKey, RSAEncryptionPadding.OaepSHA1).GetStringByUtf8();
        Assert.Equal(original, decrypt);
    }

#endif
}