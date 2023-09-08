namespace Zaabee.Cryptography.UnitTest;

public class Md5Test
{
    [Theory]
    [InlineData("apple", "1F3870BE274F6C49B3E31A0C6728957F")]
    public void Md5StringTest(string str, string result)
    {
        Assert.Equal(str.ToMd5String(), result);
    }

    [Theory]
    [InlineData("apple", "1F3870BE274F6C49B3E31A0C6728957F")]
    public void Md5BytesTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        Assert.True(bytes.ToMd5().SequenceEqual(result.FromHexString()));
        Assert.True(bytes.ToMd5(0, bytes.Length).SequenceEqual(result.FromHexString()));
    }

    [Theory]
    [InlineData("apple", "1F3870BE274F6C49B3E31A0C6728957F")]
    public void Md5StreamTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());
        Assert.True(memoryStream.ToMd5().SequenceEqual(result.FromHexString()));
    }

#if !NET48
    [Theory]
    [InlineData("apple", "1F3870BE274F6C49B3E31A0C6728957F")]
    public async Task Md5StreamAsyncTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());
        var md5Bytes = await memoryStream.ToMd5Async();
        Assert.True(md5Bytes.SequenceEqual(result.FromHexString()));
    }
#endif
}