namespace Aoxe.Cryptography.UnitTest;

public class RsaTest
{
    #region Bytes

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void EncryptAndDecryptByBytesTest(string data)
    {
        var (privateKey, publicKey) = RsaHelper.GenerateParameters();
        var encryptBytes = data.GetUtf8Bytes().EncryptByRsa(publicKey);
        var decrypt = encryptBytes.DecryptByRsa(privateKey).GetStringByUtf8();
        Assert.Equal(data, decrypt);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void SignAndVerifyDataByBytesTest(string data)
    {
        var (privateKey, publicKey) = RsaHelper.GenerateParameters();
        var dataBytes = data.GetUtf8Bytes();
        var signature = dataBytes.SignDataByRsa(privateKey);
        Assert.True(dataBytes.VerifyDataByRsa(signature, publicKey));
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void SignAndVerifyHashByBytesTest(string data)
    {
        var (privateKey, publicKey) = RsaHelper.GenerateParameters();
        var dataBytes = data.GetUtf8Bytes().ToSha256();
        var signature = dataBytes.SignHashByRsa(privateKey);
        Assert.True(dataBytes.VerifyHashByRsa(signature, publicKey));
    }

#if !NET48

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void EncryptAndDecryptByBytesWithBytesKeyTest(string data)
    {
        var (privateKey, publicKey) = RsaHelper.GenerateKeys();
        var encryptBytes = data.GetUtf8Bytes().EncryptByRsa(publicKey);
        var decrypt = encryptBytes.DecryptByRsa(privateKey).GetStringByUtf8();
        Assert.Equal(data, decrypt);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void SignAndVerifyDataByBytesWithBytesKeyTest(string data)
    {
        var (privateKey, publicKey) = RsaHelper.GenerateKeys();
        var dataBytes = data.GetUtf8Bytes();
        var signature = dataBytes.SignDataByRsa(privateKey);
        Assert.True(dataBytes.VerifyDataByRsa(signature, publicKey));
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void SignAndVerifyHashByBytesWithBytesKeyTest(string data)
    {
        var (privateKey, publicKey) = RsaHelper.GenerateKeys();
        var dataBytes = data.GetUtf8Bytes().ToSha256();
        var signature = dataBytes.SignHashByRsa(privateKey);
        Assert.True(dataBytes.VerifyHashByRsa(signature, publicKey));
    }

#endif

    #endregion

    #region ReadOnlySpan

#if NET7_0_OR_GREATER

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void EncryptAndDecryptByReadOnlySpanTest(string data)
    {
        var (privateKey, publicKey) = RsaHelper.GenerateParameters();
        ReadOnlySpan<byte> readOnlySpan = data.GetUtf8Bytes().AsSpan();
        ReadOnlySpan<byte> encryptBytes = readOnlySpan.EncryptByRsa(publicKey).AsSpan();
        var decrypt = encryptBytes.DecryptByRsa(privateKey).GetStringByUtf8();
        Assert.Equal(data, decrypt);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void SignAndVerifyDataByReadOnlySpanTest(string data)
    {
        var (privateKey, publicKey) = RsaHelper.GenerateParameters();
        ReadOnlySpan<byte> readOnlySpan = data.GetUtf8Bytes().AsSpan();
        var signature = readOnlySpan.SignDataByRsa(privateKey);
        Assert.True(readOnlySpan.VerifyDataByRsa(signature, publicKey));
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void SignAndVerifyHashByReadOnlySpanTest(string data)
    {
        var (privateKey, publicKey) = RsaHelper.GenerateParameters();
        ReadOnlySpan<byte> readOnlySpan = data.GetUtf8Bytes().ToSha256().AsSpan();
        var signature = readOnlySpan.SignHashByRsa(privateKey);
        Assert.True(readOnlySpan.VerifyHashByRsa(signature, publicKey));
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void EncryptAndDecryptByReadOnlySpanWithBytesKeyTest(string data)
    {
        var (privateKey, publicKey) = RsaHelper.GenerateKeys();
        ReadOnlySpan<byte> readOnlySpan = data.GetUtf8Bytes().AsSpan();
        ReadOnlySpan<byte> encryptBytes = readOnlySpan.EncryptByRsa(publicKey).AsSpan();
        var decrypt = encryptBytes.DecryptByRsa(privateKey).GetStringByUtf8();
        Assert.Equal(data, decrypt);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void SignAndVerifyDataByReadOnlySpanWithBytesKeyTest(string data)
    {
        var (privateKey, publicKey) = RsaHelper.GenerateKeys();
        ReadOnlySpan<byte> readOnlySpan = data.GetUtf8Bytes().AsSpan();
        var signature = readOnlySpan.SignDataByRsa(privateKey);
        Assert.True(readOnlySpan.VerifyDataByRsa(signature, publicKey));
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void SignAndVerifyHashByReadOnlySpanWithBytesKeyTest(string data)
    {
        var (privateKey, publicKey) = RsaHelper.GenerateKeys();
        ReadOnlySpan<byte> readOnlySpan = data.GetUtf8Bytes().ToSha256().AsSpan();
        var signature = readOnlySpan.SignHashByRsa(privateKey);
        Assert.True(readOnlySpan.VerifyHashByRsa(signature, publicKey));
    }
#endif

    #endregion
}
