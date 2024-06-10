using Aoxe.Cryptography.HashAlgorithm.SHA512;

namespace Aoxe.Cryptography.UnitTest;

public class Sha512Test
{
    [Theory]
    [InlineData(
        "apple",
        "844D8779103B94C18F4AA4CC0C3B4474058580A991FBA85D3CA698A0BC9E52C5940FEB7A65A3A290E17E6B23EE943ECC4F73E7490327245B4FE5D5EFB590FEB2"
    )]
    public void Sha512StringTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        Assert.Equal(bytes.ToSha512String(), result);
        Assert.Equal(bytes.ToSha512String(0, bytes.Length), result);
        Assert.Equal(ms.ToSha512String(), result);
        Assert.Equal(str.ToSha512String(), result);
    }

    [Theory]
    [InlineData(
        "apple",
        "844D8779103B94C18F4AA4CC0C3B4474058580A991FBA85D3CA698A0BC9E52C5940FEB7A65A3A290E17E6B23EE943ECC4F73E7490327245B4FE5D5EFB590FEB2"
    )]
    public void Sha512BytesTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        var hash = result.FromHex();
        Assert.True(bytes.ToSha512().SequenceEqual(hash));
        Assert.True(bytes.ToSha512(0, bytes.Length).SequenceEqual(hash));
        Assert.True(ms.ToSha512().SequenceEqual(hash));
        Assert.True(str.ToSha512().SequenceEqual(hash));
    }

#if !NET48
    [Theory]
    [InlineData(
        "apple",
        "844D8779103B94C18F4AA4CC0C3B4474058580A991FBA85D3CA698A0BC9E52C5940FEB7A65A3A290E17E6B23EE943ECC4F73E7490327245B4FE5D5EFB590FEB2"
    )]
    public async Task Sha512StreamAsyncTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());

        var sha512Bytes = await memoryStream.ToSha512Async();
        Assert.True(sha512Bytes.SequenceEqual(result.FromHex()));

        var sha512String = await memoryStream.ToSha512StringAsync();
        Assert.Equal(result, sha512String);
    }
#endif
}
