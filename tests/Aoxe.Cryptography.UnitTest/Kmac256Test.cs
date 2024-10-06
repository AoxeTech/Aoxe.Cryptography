#if NET9_0_OR_GREATER
namespace Aoxe.Cryptography.UnitTest;

public class Kmac256Test
{
    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        64,
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public void Kmac256StringTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var customizationBytes = customization.GetUtf8Bytes();
        var readOnlySpan = new ReadOnlySpan<byte>(bytes);
        var ms = new MemoryStream(bytes);
        Assert.Equal(bytes.ToKmac256String(keyBytes, outputLength, customizationBytes), result);
        Assert.Equal(
            readOnlySpan.ToKmac256String(keyBytes, outputLength, customizationBytes),
            result
        );
        Assert.Equal(ms.ToKmac256String(keyBytes, outputLength, customizationBytes), result);
        Assert.Equal(source.ToKmac256String(keyBytes, outputLength, customizationBytes), result);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        64,
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public async Task Kmac256AsyncTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var customizationBytes = customization.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        Assert.Equal(
            (await ms.ToKmac256Async(keyBytes, outputLength, customizationBytes)).ToHexString(),
            result
        );
        ms.TrySeek(0, SeekOrigin.Begin);
        Assert.Equal(
            await ms.ToKmac256StringAsync(keyBytes, outputLength, customizationBytes),
            result
        );
        var memory = new Memory<byte>();
        ms.TrySeek(0, SeekOrigin.Begin);
        await ms.ToKmac256Async(keyBytes, memory, customizationBytes);
        Assert.Empty(memory.ToArray());
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        64,
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public void Kmac256BytesTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var customizationBytes = customization.GetUtf8Bytes();
        var readOnlySpan = new ReadOnlySpan<byte>(bytes);
        var ms = new MemoryStream(bytes);
        var hash = result.FromHex();
        Assert.True(
            bytes.ToKmac256(keyBytes, outputLength, customizationBytes).SequenceEqual(hash)
        );
        Assert.True(
            readOnlySpan.ToKmac256(keyBytes, outputLength, customizationBytes).SequenceEqual(hash)
        );
        Assert.True(ms.ToKmac256(keyBytes, outputLength, customizationBytes).SequenceEqual(hash));
        Assert.True(
            source.ToKmac256(keyBytes, outputLength, customizationBytes).SequenceEqual(hash)
        );
    }

    [Theory]
    [InlineData("aoxe", "this is a key")]
    public void Kmac256FillTest(string source, string key)
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var readOnlySpan = new ReadOnlySpan<byte>(bytes);
        var ms = new MemoryStream(bytes);

        var readOnlySpanResult = new Span<byte>();
        var msResult = new Span<byte>();
        var stringResult = new Span<byte>();

        readOnlySpan.ToKmac256(keyBytes, readOnlySpanResult);
        ms.ToKmac256(keyBytes, msResult);
        source.ToKmac256(keyBytes, stringResult);

        Assert.Empty(readOnlySpanResult.ToArray());
        Assert.Empty(msResult.ToArray());
        Assert.Empty(stringResult.ToArray());
    }
}
#endif
