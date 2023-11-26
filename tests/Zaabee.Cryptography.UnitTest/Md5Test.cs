namespace Zaabee.Cryptography.UnitTest;

public class Md5Test
{
    [Theory]
    [InlineData("apple", "1F3870BE274F6C49B3E31A0C6728957F")]
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
    [InlineData("apple", "1F3870BE274F6C49B3E31A0C6728957F")]
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
    [InlineData("apple", "1F3870BE274F6C49B3E31A0C6728957F")]
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
