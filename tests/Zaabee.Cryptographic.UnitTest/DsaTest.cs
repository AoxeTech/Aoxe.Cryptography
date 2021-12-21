namespace Zaabee.Cryptographic.UnitTest;

public class DsaTest
{
    [Fact]
    public void Test()
    {
        DsaHelper.Encoding = Encoding.UTF8;
        Assert.Equal(DsaHelper.Encoding, Encoding.UTF8);
    }

    [Theory]
    [InlineData("Here is some data to encrypt!")]
    public void BytesTest(string original)
    {
        var (privateKey, publicKey) = DsaHelper.GenerateParameters();
        var originalBytes = DsaHelper.Encoding.GetBytes(original);
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