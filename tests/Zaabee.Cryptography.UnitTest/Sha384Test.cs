namespace Zaabee.Cryptography.UnitTest;

public class Sha384Test
{
    [Theory]
    [InlineData("apple",
        "3D8786FCB588C93348756C6429717DC6C374A14F7029362281A3B21DC10250DDF0D0578052749822EB08BC0DC1E68B0F")]
    public void Sha384StringTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        Assert.Equal(bytes.ToSha384String(), result);
        Assert.Equal(bytes.ToSha384String(0, bytes.Length), result);
        Assert.Equal(ms.ToSha384String(), result);
        Assert.Equal(str.ToSha384String(), result);
    }

    [Theory]
    [InlineData("apple",
        "3D8786FCB588C93348756C6429717DC6C374A14F7029362281A3B21DC10250DDF0D0578052749822EB08BC0DC1E68B0F")]
    public void Sha384BytesTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        var hash = result.FromHexString();
        Assert.True(bytes.ToSha384().SequenceEqual(hash));
        Assert.True(bytes.ToSha384(0, bytes.Length).SequenceEqual(hash));
        Assert.True(ms.ToSha384().SequenceEqual(hash));
        Assert.True(str.ToSha384().SequenceEqual(hash));
    }

#if !NET48
    [Theory]
    [InlineData("apple",
        "3D8786FCB588C93348756C6429717DC6C374A14F7029362281A3B21DC10250DDF0D0578052749822EB08BC0DC1E68B0F")]
    public async Task Sha384StreamAsyncTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());

        var sha384Bytes = await memoryStream.ToSha384Async();
        Assert.True(sha384Bytes.SequenceEqual(result.FromHexString()));

        var sha384String = await memoryStream.ToSha384StringAsync();
        Assert.Equal(result, sha384String);
    }
#endif
}