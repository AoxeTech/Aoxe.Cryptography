using Aoxe.Cryptography.HashAlgorithm.SHA512;

namespace Aoxe.Cryptography.UnitTest;

public class Sha512Test
{
    [Theory]
    [InlineData(
        "aoxe",
        "1BA1C956B890E58B0F48D98BB66BB05E34B2897967453AE0D7920B3CBC1779C29ECCFE3596F2F12629639FC0D05CE8B5B7E79FB0808F90C3599C08092263985B"
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
        "aoxe",
        "1BA1C956B890E58B0F48D98BB66BB05E34B2897967453AE0D7920B3CBC1779C29ECCFE3596F2F12629639FC0D05CE8B5B7E79FB0808F90C3599C08092263985B"
    )]
    public void Sha512BytesTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        var hash = result.FromHexToBytes();
        Assert.True(bytes.ToSha512().SequenceEqual(hash));
        Assert.True(bytes.ToSha512(0, bytes.Length).SequenceEqual(hash));
        Assert.True(ms.ToSha512().SequenceEqual(hash));
        Assert.True(str.ToSha512().SequenceEqual(hash));
    }

    [Theory]
    [InlineData(
        "aoxe",
        "1BA1C956B890E58B0F48D98BB66BB05E34B2897967453AE0D7920B3CBC1779C29ECCFE3596F2F12629639FC0D05CE8B5B7E79FB0808F90C3599C08092263985B"
    )]
    public async Task Sha512StreamAsyncTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());

        var sha512Bytes = await memoryStream.ToSha512Async();
        Assert.True(sha512Bytes.SequenceEqual(result.FromHexToBytes()));

        var sha512String = await memoryStream.ToSha512StringAsync();
        Assert.Equal(result, sha512String);
    }
}
