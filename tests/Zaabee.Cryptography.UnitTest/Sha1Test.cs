namespace Zaabee.Cryptography.UnitTest;

public class Sha1Test
{
    [Theory]
    [InlineData("apple", "D0-BE-2D-C4-21-BE-4F-CD-01-72-E5-AF-CE-EA-39-70-E2-F3-D9-40")]
    public void Sha1StringTest(string str, string result)
    {
        Assert.Equal(str.ToSha1(), result);
    }

    [Theory]
    [InlineData("apple", "D0-BE-2D-C4-21-BE-4F-CD-01-72-E5-AF-CE-EA-39-70-E2-F3-D9-40")]
    public void Sha1BytesTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        Assert.True(bytes.ToSha1().SequenceEqual(CommonHelper.HexToBytes(result)));
        Assert.True(bytes.ToSha1(0, bytes.Length).SequenceEqual(CommonHelper.HexToBytes(result)));
    }

    [Theory]
    [InlineData("apple", "D0-BE-2D-C4-21-BE-4F-CD-01-72-E5-AF-CE-EA-39-70-E2-F3-D9-40")]
    public void Sha1StreamTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());
        Assert.True(memoryStream.ToSha1().SequenceEqual(CommonHelper.HexToBytes(result)));
    }

#if !NET48
    [Theory]
    [InlineData("apple", "D0-BE-2D-C4-21-BE-4F-CD-01-72-E5-AF-CE-EA-39-70-E2-F3-D9-40")]
    public async Task Sha1StreamAsyncTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());
        var sha1Bytes = await memoryStream.ToSha1Async();
        Assert.True(sha1Bytes.SequenceEqual(CommonHelper.HexToBytes(result)));
    }
#endif
}