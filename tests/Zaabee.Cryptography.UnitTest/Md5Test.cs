namespace Zaabee.Cryptography.UnitTest;

public class Md5Test
{
    [Theory]
    [InlineData("apple", "1F-38-70-BE-27-4F-6C-49-B3-E3-1A-0C-67-28-95-7F")]
    public void Md5StringTest(string str, string result)
    {
        Assert.Equal(str.ToMd5(), result);
    }

    [Theory]
    [InlineData("apple", "1F-38-70-BE-27-4F-6C-49-B3-E3-1A-0C-67-28-95-7F")]
    public void Md5BytesTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        Assert.True(bytes.ToMd5().SequenceEqual(CommonHelper.HexToBytes(result)));
        Assert.True(bytes.ToMd5(0, bytes.Length).SequenceEqual(CommonHelper.HexToBytes(result)));
    }

    [Theory]
    [InlineData("apple", "1F-38-70-BE-27-4F-6C-49-B3-E3-1A-0C-67-28-95-7F")]
    public void Md5StreamTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());
        Assert.True(memoryStream.ToMd5().SequenceEqual(CommonHelper.HexToBytes(result)));
    }

#if !NET48
    [Theory]
    [InlineData("apple", "1F-38-70-BE-27-4F-6C-49-B3-E3-1A-0C-67-28-95-7F")]
    public async Task Md5StreamAsyncTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());
        var md5Bytes = await memoryStream.ToMd5Async();
        Assert.True(md5Bytes.SequenceEqual(CommonHelper.HexToBytes(result)));
    }
#endif
}