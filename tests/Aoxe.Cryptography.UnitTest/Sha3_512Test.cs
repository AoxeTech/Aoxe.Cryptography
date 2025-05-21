#if NET8_0_OR_GREATER
namespace Aoxe.Cryptography.UnitTest;

public class Sha3_512Test
{
    [Theory]
    [InlineData(
        "aoxe",
        "AE6D6A7AADB3A5CE94DB5068E6AA4BCA470F83563C61FC1BC44B332DD18B406501FAE1E8D14D255E83A22CC33CE970FCDBF8E7A283AA4D530B6ADEA247EF1FE8"
    )]
    public void Sha3_512StringTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        Assert.Equal(bytes.ToSha3_512String(), result);
        Assert.Equal(bytes.ToSha3_512String(0, bytes.Length), result);
        Assert.Equal(ms.ToSha3_512String(), result);
        Assert.Equal(str.ToSha3_512String(), result);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "AE6D6A7AADB3A5CE94DB5068E6AA4BCA470F83563C61FC1BC44B332DD18B406501FAE1E8D14D255E83A22CC33CE970FCDBF8E7A283AA4D530B6ADEA247EF1FE8"
    )]
    public void Sha3_512BytesTest(string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        var hash = result.FromHexToBytes();
        Assert.True(bytes.ToSha3_512().SequenceEqual(hash));
        Assert.True(bytes.ToSha3_512(0, bytes.Length).SequenceEqual(hash));
        Assert.True(ms.ToSha3_512().SequenceEqual(hash));
        Assert.True(str.ToSha3_512().SequenceEqual(hash));
    }

    [Theory]
    [InlineData(
        "aoxe",
        "AE6D6A7AADB3A5CE94DB5068E6AA4BCA470F83563C61FC1BC44B332DD18B406501FAE1E8D14D255E83A22CC33CE970FCDBF8E7A283AA4D530B6ADEA247EF1FE8"
    )]
    public async Task Sha3_512StreamAsyncTest(string str, string result)
    {
        var memoryStream = new MemoryStream(str.GetUtf8Bytes());

        var sha3_512Bytes = await memoryStream.ToSha3_512Async();
        Assert.True(sha3_512Bytes.SequenceEqual(result.FromHexToBytes()));

        var sha3_512String = await memoryStream.ToSha3_512StringAsync();
        Assert.Equal(result, sha3_512String);
    }
}
#endif
