namespace Aoxe.Cryptography.UnitTest;

public class Sha256Test
{
    [Theory]
    [InlineData("apple", "3A7BD3E2360A3D29EEA436FCFB7E44C735D117C42D1C1835420B6B9942DD4F1B")]
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
    [InlineData("apple", "3A7BD3E2360A3D29EEA436FCFB7E44C735D117C42D1C1835420B6B9942DD4F1B")]
    public void Sha256BytesTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        var hash = result.FromHex();
        Assert.True(bytes.ToSha256().SequenceEqual(hash));
        Assert.True(bytes.ToSha256(0, bytes.Length).SequenceEqual(hash));
        Assert.True(ms.ToSha256().SequenceEqual(hash));
        Assert.True(str.ToSha256().SequenceEqual(hash));
    }

#if !NET48
    [Theory]
    [InlineData("apple", "3A7BD3E2360A3D29EEA436FCFB7E44C735D117C42D1C1835420B6B9942DD4F1B")]
    public async Task Sha256StreamAsyncTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());

        var sha256Bytes = await memoryStream.ToSha256Async();
        Assert.True(sha256Bytes.SequenceEqual(result.FromHex()));

        var sha256String = await memoryStream.ToSha256StringAsync();
        Assert.Equal(result, sha256String);
    }
#endif
}
