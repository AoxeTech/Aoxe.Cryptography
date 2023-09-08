namespace Zaabee.Cryptography.UnitTest;

public class Sha1Test
{
    [Theory]
    [InlineData("apple", "D0BE2DC421BE4FCD0172E5AFCEEA3970E2F3D940")]
    public void Sha1StringTest(string str, string result)
    {
        Assert.Equal(str.ToSha1String(), result);
    }

    [Theory]
    [InlineData("apple", "D0BE2DC421BE4FCD0172E5AFCEEA3970E2F3D940")]
    public void Sha1BytesTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        Assert.True(bytes.ToSha1().SequenceEqual(result.FromHexString()));
        Assert.True(bytes.ToSha1(0, bytes.Length).SequenceEqual(result.FromHexString()));
    }

    [Theory]
    [InlineData("apple", "D0BE2DC421BE4FCD0172E5AFCEEA3970E2F3D940")]
    public void Sha1StreamTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());
        Assert.True(memoryStream.ToSha1().SequenceEqual(result.FromHexString()));
    }

#if !NET48
    [Theory]
    [InlineData("apple", "D0BE2DC421BE4FCD0172E5AFCEEA3970E2F3D940")]
    public async Task Sha1StreamAsyncTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());
        var sha1Bytes = await memoryStream.ToSha1Async();
        Assert.True(sha1Bytes.SequenceEqual(result.FromHexString()));
    }
#endif
}