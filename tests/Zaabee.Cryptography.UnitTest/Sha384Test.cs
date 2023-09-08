using Zaabee.Cryptography.HashAlgorithm.SHA384;

namespace Zaabee.Cryptography.UnitTest;

public class Sha384Test
{
    [Theory]
    [InlineData("apple",
        "3D8786FCB588C93348756C6429717DC6C374A14F7029362281A3B21DC10250DDF0D0578052749822EB08BC0DC1E68B0F")]
    public void Sha384StringTest(string str, string result)
    {
        Assert.Equal(str.ToSha384String(), result);
    }

    [Theory]
    [InlineData("apple",
        "3D8786FCB588C93348756C6429717DC6C374A14F7029362281A3B21DC10250DDF0D0578052749822EB08BC0DC1E68B0F")]
    public void Sha384BytesTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        Assert.True(bytes.ToSha384().SequenceEqual(result.FromHexString()));
        Assert.True(bytes.ToSha384(0, bytes.Length).SequenceEqual(result.FromHexString()));
    }

    [Theory]
    [InlineData("apple",
        "3D8786FCB588C93348756C6429717DC6C374A14F7029362281A3B21DC10250DDF0D0578052749822EB08BC0DC1E68B0F")]
    public void Sha384StreamTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());
        Assert.True(memoryStream.ToSha384().SequenceEqual(result.FromHexString()));
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
    }
#endif
}