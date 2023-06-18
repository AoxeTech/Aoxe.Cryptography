namespace Zaabee.Cryptography.UnitTest;

public class Sha256Test
{
    [Theory]
    [InlineData("apple",
        "3A-7B-D3-E2-36-0A-3D-29-EE-A4-36-FC-FB-7E-44-C7-35-D1-17-C4-2D-1C-18-35-42-0B-6B-99-42-DD-4F-1B")]
    public void Sha256StringTest(string str, string result)
    {
        Assert.Equal(str.ToSha256(), result);
    }

    [Theory]
    [InlineData("apple",
        "3A-7B-D3-E2-36-0A-3D-29-EE-A4-36-FC-FB-7E-44-C7-35-D1-17-C4-2D-1C-18-35-42-0B-6B-99-42-DD-4F-1B")]
    public void Sha256BytesTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        Assert.True(bytes.ToSha256().SequenceEqual(CommonHelper.HexToBytes(result)));
        Assert.True(bytes.ToSha256(0, bytes.Length).SequenceEqual(CommonHelper.HexToBytes(result)));
    }

    [Theory]
    [InlineData("apple",
        "3A-7B-D3-E2-36-0A-3D-29-EE-A4-36-FC-FB-7E-44-C7-35-D1-17-C4-2D-1C-18-35-42-0B-6B-99-42-DD-4F-1B")]
    public void Sha256StreamTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());
        Assert.True(memoryStream.ToSha256().SequenceEqual(CommonHelper.HexToBytes(result)));
    }

#if !NET48
    [Theory]
    [InlineData("apple",
        "3A-7B-D3-E2-36-0A-3D-29-EE-A4-36-FC-FB-7E-44-C7-35-D1-17-C4-2D-1C-18-35-42-0B-6B-99-42-DD-4F-1B")]
    public async Task Sha256StreamAsyncTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());
        var sha256Bytes = await memoryStream.ToSha256Async();
        Assert.True(sha256Bytes.SequenceEqual(CommonHelper.HexToBytes(result)));
    }
#endif
}