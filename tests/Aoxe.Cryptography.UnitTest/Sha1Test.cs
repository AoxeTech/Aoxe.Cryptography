namespace Aoxe.Cryptography.UnitTest;

public class Sha1Test
{
    [Theory]
    [InlineData("aoxe", "B769BA21C57A0611FD0E6DDC4D9F9A5BE0DEEE9D")]
    public void Sha1StringTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        Assert.Equal(bytes.ToSha1String(), result);
        Assert.Equal(bytes.ToSha1String(0, bytes.Length), result);
        Assert.Equal(ms.ToSha1String(), result);
        Assert.Equal(str.ToSha1String(), result);
    }

    [Theory]
    [InlineData("aoxe", "B769BA21C57A0611FD0E6DDC4D9F9A5BE0DEEE9D")]
    public void Sha1BytesTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        var hash = result.FromHex();
        Assert.True(bytes.ToSha1().SequenceEqual(hash));
        Assert.True(bytes.ToSha1(0, bytes.Length).SequenceEqual(hash));
        Assert.True(ms.ToSha1().SequenceEqual(hash));
        Assert.True(str.ToSha1().SequenceEqual(hash));
    }

#if !NET48
    [Theory]
    [InlineData("aoxe", "B769BA21C57A0611FD0E6DDC4D9F9A5BE0DEEE9D")]
    public async Task Sha1StreamAsyncTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());

        var sha1Bytes = await memoryStream.ToSha1Async();
        Assert.True(sha1Bytes.SequenceEqual(result.FromHex()));

        var sha1String = await memoryStream.ToSha1StringAsync();
        Assert.Equal(result, sha1String);
    }
#endif
}
