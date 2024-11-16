namespace Aoxe.Cryptography.UnitTest;

public class DsaTest
{
    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void BytesSignatureTest(string original)
    {
        var (privateKey, publicKey) = DsaHelper.GenerateParameters();
        var originalBytes = original.GetUtf8Bytes();
        var signature = originalBytes.CreateSignatureByDsa(privateKey);
        Assert.True(originalBytes.VerifySignatureByDsa(signature, publicKey));
    }

#if NET8_0_OR_GREATER
    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void BytesDataMd5Test(string original)
    {
        var (privateKey, publicKey) = DsaHelper.GenerateParameters();
        var originalBytes = original.GetUtf8Bytes();
        var signature = originalBytes.SignDataByDsa(privateKey, HashAlgorithmName.MD5);
        Assert.True(originalBytes.VerifyDataByDsa(signature, publicKey, HashAlgorithmName.MD5));
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void BytesDataSHhaTest(string original)
    {
        var (privateKey, publicKey) = DsaHelper.GenerateParameters();
        var originalBytes = original.GetUtf8Bytes();
        var signature = originalBytes.SignDataByDsa(privateKey, HashAlgorithmName.SHA1);
        Assert.True(originalBytes.VerifyDataByDsa(signature, publicKey, HashAlgorithmName.SHA1));
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void BytesDataSha256Test(string original)
    {
        var (privateKey, publicKey) = DsaHelper.GenerateParameters();
        var originalBytes = original.GetUtf8Bytes();
        var signature = originalBytes.SignDataByDsa(privateKey, HashAlgorithmName.SHA256);
        Assert.True(originalBytes.VerifyDataByDsa(signature, publicKey, HashAlgorithmName.SHA256));
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void BytesDataSha384Test(string original)
    {
        var (privateKey, publicKey) = DsaHelper.GenerateParameters();
        var originalBytes = original.GetUtf8Bytes();
        var signature = originalBytes.SignDataByDsa(privateKey, HashAlgorithmName.SHA384);
        Assert.True(originalBytes.VerifyDataByDsa(signature, publicKey, HashAlgorithmName.SHA384));
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void BytesDataSha512Test(string original)
    {
        var (privateKey, publicKey) = DsaHelper.GenerateParameters();
        var originalBytes = original.GetUtf8Bytes();
        var signature = originalBytes.SignDataByDsa(privateKey, HashAlgorithmName.SHA512);
        Assert.True(originalBytes.VerifyDataByDsa(signature, publicKey, HashAlgorithmName.SHA512));
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void BytesDataSha3_256Test(string original)
    {
        var (privateKey, publicKey) = DsaHelper.GenerateParameters();
        var originalBytes = original.GetUtf8Bytes();
        var signature = originalBytes.SignDataByDsa(privateKey, HashAlgorithmName.SHA3_256);
        Assert.True(
            originalBytes.VerifyDataByDsa(signature, publicKey, HashAlgorithmName.SHA3_256)
        );
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void BytesDataSha3_384Test(string original)
    {
        var (privateKey, publicKey) = DsaHelper.GenerateParameters();
        var originalBytes = original.GetUtf8Bytes();
        var signature = originalBytes.SignDataByDsa(privateKey, HashAlgorithmName.SHA3_384);
        Assert.True(
            originalBytes.VerifyDataByDsa(signature, publicKey, HashAlgorithmName.SHA3_384)
        );
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void BytesDataSha3_512Test(string original)
    {
        var (privateKey, publicKey) = DsaHelper.GenerateParameters();
        var originalBytes = original.GetUtf8Bytes();
        var signature = originalBytes.SignDataByDsa(privateKey, HashAlgorithmName.SHA3_512);
        Assert.True(
            originalBytes.VerifyDataByDsa(signature, publicKey, HashAlgorithmName.SHA3_512)
        );
    }
#endif
}
