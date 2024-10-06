namespace Aoxe.Cryptography.UnitTest;

public class Md5Test
{
    [Theory]
    [InlineData("aoxe", "53F07A4188C9B00265EDE3CE81D64801")]
    public void Md5StringTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        Assert.Equal(bytes.ToMd5String(), result);
        Assert.Equal(bytes.ToMd5String(0, bytes.Length), result);
        Assert.Equal(ms.ToMd5String(), result);
        Assert.Equal(str.ToMd5String(), result);
    }

    [Theory]
    [InlineData("aoxe", "53F07A4188C9B00265EDE3CE81D64801")]
    public void Md5BytesTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        var hash = result.FromHex();
        Assert.True(bytes.ToMd5().SequenceEqual(hash));
        Assert.True(bytes.ToMd5(0, bytes.Length).SequenceEqual(hash));
        Assert.True(ms.ToMd5().SequenceEqual(hash));
        Assert.True(str.ToMd5().SequenceEqual(hash));
    }

#if !NET48
    [Theory]
    [InlineData("aoxe", "53F07A4188C9B00265EDE3CE81D64801")]
    public async Task Md5StreamAsyncTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());

        var md5Bytes = await memoryStream.ToMd5Async();
        Assert.True(md5Bytes.SequenceEqual(result.FromHex()));

        var md5String = await memoryStream.ToMd5StringAsync();
        Assert.Equal(result, md5String);
    }
#endif
}
