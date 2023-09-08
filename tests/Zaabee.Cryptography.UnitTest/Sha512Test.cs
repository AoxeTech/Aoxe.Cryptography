using Zaabee.Cryptography.HashAlgorithm.SHA512;

namespace Zaabee.Cryptography.UnitTest;

public class Sha512Test
{
    [Theory]
    [InlineData("apple",
        "844D8779103B94C18F4AA4CC0C3B4474058580A991FBA85D3CA698A0BC9E52C5940FEB7A65A3A290E17E6B23EE943ECC4F73E7490327245B4FE5D5EFB590FEB2")]
    public void Sha512StringTest(string str, string result)
    {
        Assert.Equal(str.ToSha512String(), result);
    }

    [Theory]
    [InlineData("apple",
        "844D8779103B94C18F4AA4CC0C3B4474058580A991FBA85D3CA698A0BC9E52C5940FEB7A65A3A290E17E6B23EE943ECC4F73E7490327245B4FE5D5EFB590FEB2")]
    public void Sha512BytesTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        Assert.True(bytes.ToSha512().SequenceEqual(result.FromHexString()));
        Assert.True(bytes.ToSha512(0, bytes.Length).SequenceEqual(result.FromHexString()));
    }

    [Theory]
    [InlineData("apple",
        "844D8779103B94C18F4AA4CC0C3B4474058580A991FBA85D3CA698A0BC9E52C5940FEB7A65A3A290E17E6B23EE943ECC4F73E7490327245B4FE5D5EFB590FEB2")]
    public void Sha512StreamTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());
        Assert.True(memoryStream.ToSha512().SequenceEqual(result.FromHexString()));
    }

#if !NET48
    [Theory]
    [InlineData("apple",
        "844D8779103B94C18F4AA4CC0C3B4474058580A991FBA85D3CA698A0BC9E52C5940FEB7A65A3A290E17E6B23EE943ECC4F73E7490327245B4FE5D5EFB590FEB2")]
    public async Task Sha512StreamAsyncTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());
        var sha512Bytes = await memoryStream.ToSha512Async();
        Assert.True(sha512Bytes.SequenceEqual(result.FromHexString()));
    }
#endif
}