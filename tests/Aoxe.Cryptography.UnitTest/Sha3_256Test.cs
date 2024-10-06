#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.UnitTest;

public class Sha3_256Test
{
    [Theory]
    [InlineData("aoxe", "A8E39DE774FD3D4A69EDF97E99FA8B6566DD1457F9ABA25E4FCAADD63678C37B")]
    public void Sha3_256StringTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        Assert.Equal(bytes.ToSha3_256String(), result);
        Assert.Equal(bytes.ToSha3_256String(0, bytes.Length), result);
        Assert.Equal(ms.ToSha3_256String(), result);
        Assert.Equal(str.ToSha3_256String(), result);
    }

    [Theory]
    [InlineData("aoxe", "A8E39DE774FD3D4A69EDF97E99FA8B6566DD1457F9ABA25E4FCAADD63678C37B")]
    public void Sha3_256BytesTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        var hash = result.FromHex();
        Assert.True(bytes.ToSha3_256().SequenceEqual(hash));
        Assert.True(bytes.ToSha3_256(0, bytes.Length).SequenceEqual(hash));
        Assert.True(ms.ToSha3_256().SequenceEqual(hash));
        Assert.True(str.ToSha3_256().SequenceEqual(hash));
    }

    [Theory]
    [InlineData("aoxe", "A8E39DE774FD3D4A69EDF97E99FA8B6566DD1457F9ABA25E4FCAADD63678C37B")]
    public async Task Sha3_256StreamAsyncTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());

        var sha3_256Bytes = await memoryStream.ToSha3_256Async();
        Assert.True(sha3_256Bytes.SequenceEqual(result.FromHex()));

        var sha3_256String = await memoryStream.ToSha3_256StringAsync();
        Assert.Equal(result, sha3_256String);
    }
}
#endif
