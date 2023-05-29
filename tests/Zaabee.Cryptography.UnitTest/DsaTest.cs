namespace Zaabee.Cryptography.UnitTest;

public class DsaTest
{
    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void BytesTest(string original)
    {
        var (privateKey, publicKey) = DsaHelper.GenerateParameters();
        var originalBytes = original.GetUtf8Bytes();
        var signature = originalBytes.CreateSignatureByDsa(privateKey);
        Assert.True(originalBytes.VerifySignatureByDsa(signature, publicKey));
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void StringTest(string original)
    {
        var (privateKey, publicKey) = DsaHelper.GenerateParameters();
        var signature = original.CreateSignatureByDsa(privateKey);
        Assert.True(original.VerifySignatureByDsa(signature, publicKey));
    }
}