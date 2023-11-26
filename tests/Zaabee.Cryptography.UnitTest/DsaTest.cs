namespace Zaabee.Cryptography.UnitTest;

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

#if !NET48
    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void BytesDataTest(string original)
    {
        var (privateKey, publicKey) = DsaHelper.GenerateParameters();
        var originalBytes = original.GetUtf8Bytes();
        var signature = originalBytes.SignDataByDsa(privateKey);
        Assert.True(originalBytes.VerifyDataByDsa(signature, publicKey));
    }
#endif
}
