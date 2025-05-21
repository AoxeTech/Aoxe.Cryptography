#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.UnitTest;

public class Sha3_384Test
{
    [Theory]
    [InlineData(
        "aoxe",
        "24C04A1DD861D48BCB670299D82D90C61001596160E5E71023090389BB823F1527F10B73D00738F8C0E8BBCE63C34A1F"
    )]
    public void Sha3_384StringTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        Assert.Equal(bytes.ToSha3_384String(), result);
        Assert.Equal(bytes.ToSha3_384String(0, bytes.Length), result);
        Assert.Equal(ms.ToSha3_384String(), result);
        Assert.Equal(str.ToSha3_384String(), result);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "24C04A1DD861D48BCB670299D82D90C61001596160E5E71023090389BB823F1527F10B73D00738F8C0E8BBCE63C34A1F"
    )]
    public void Sha3_384BytesTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        var hash = result.FromHexToBytes();
        Assert.True(bytes.ToSha3_384().SequenceEqual(hash));
        Assert.True(bytes.ToSha3_384(0, bytes.Length).SequenceEqual(hash));
        Assert.True(ms.ToSha3_384().SequenceEqual(hash));
        Assert.True(str.ToSha3_384().SequenceEqual(hash));
    }

    [Theory]
    [InlineData(
        "aoxe",
        "24C04A1DD861D48BCB670299D82D90C61001596160E5E71023090389BB823F1527F10B73D00738F8C0E8BBCE63C34A1F"
    )]
    public async Task Sha3_384StreamAsyncTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());

        var sha3_384Bytes = await memoryStream.ToSha3_384Async();
        Assert.True(sha3_384Bytes.SequenceEqual(result.FromHexToBytes()));

        var sha3_384String = await memoryStream.ToSha3_384StringAsync();
        Assert.Equal(result, sha3_384String);
    }
}
#endif
