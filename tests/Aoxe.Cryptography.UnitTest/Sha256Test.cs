namespace Aoxe.Cryptography.UnitTest;

public class Sha256Test
{
    [Theory]
    [InlineData("aoxe", "8B7F4C4B5E13F4546D9ACF863A78542C3EC599E533531A6F081B7EBD8120F288")]
    public void Sha256StringTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        Assert.Equal(bytes.ToSha256String(), result);
        Assert.Equal(bytes.ToSha256String(0, bytes.Length), result);
        Assert.Equal(ms.ToSha256String(), result);
        Assert.Equal(str.ToSha256String(), result);
    }

    [Theory]
    [InlineData("aoxe", "8B7F4C4B5E13F4546D9ACF863A78542C3EC599E533531A6F081B7EBD8120F288")]
    public void Sha256BytesTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        var hash = result.FromHexToBytes();
        Assert.True(bytes.ToSha256().SequenceEqual(hash));
        Assert.True(bytes.ToSha256(0, bytes.Length).SequenceEqual(hash));
        Assert.True(ms.ToSha256().SequenceEqual(hash));
        Assert.True(str.ToSha256().SequenceEqual(hash));
    }

    [Theory]
    [InlineData("aoxe", "8B7F4C4B5E13F4546D9ACF863A78542C3EC599E533531A6F081B7EBD8120F288")]
    public async Task Sha256StreamAsyncTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());

        var sha256Bytes = await memoryStream.ToSha256Async();
        Assert.True(sha256Bytes.SequenceEqual(result.FromHexToBytes()));

        var sha256String = await memoryStream.ToSha256StringAsync();
        Assert.Equal(result, sha256String);
    }
}
