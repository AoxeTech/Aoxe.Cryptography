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
    public void BytesToKmac256StringTest(
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

        Assert.Equal(bytes.ToKmac256String(keyBytes, outputLength, customizationBytes), result);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        64,
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public void ReadOnlySpanToKmac256StringWithBytesKeyTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var readOnlySpan = new ReadOnlySpan<byte>(bytes);
        var customizationBytes = customization.GetUtf8Bytes();

        Assert.Equal(
            readOnlySpan.ToKmac256String(keyBytes, outputLength, customizationBytes),
            result
        );
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        64,
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public void ReadOnlySpanToKmac256StringWithSpanKeyTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var keySpan = new ReadOnlySpan<byte>(keyBytes);
        var readOnlySpan = new ReadOnlySpan<byte>(bytes);
        var customizationBytes = customization.GetUtf8Bytes();

        Assert.Equal(
            readOnlySpan.ToKmac256String(keySpan, outputLength, customizationBytes),
            result
        );
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        64,
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public void StreamToKmac256StringWithBytesKeyTest(
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

        Assert.Equal(ms.ToKmac256String(keyBytes, outputLength, customizationBytes), result);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        64,
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public void StreamToKmac256StringWithSpanKeyTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var keySpan = new ReadOnlySpan<byte>(keyBytes);
        var customizationBytes = customization.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);

        Assert.Equal(ms.ToKmac256String(keySpan, outputLength, customizationBytes), result);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        64,
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public void StringToKmac256StringTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var keyBytes = key.GetUtf8Bytes();
        var customizationBytes = customization.GetUtf8Bytes();

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
    public async Task StreamToKmac256BytesWithBytesKeyAsyncTest(
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
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        64,
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public async Task StreamToKmac256StringWithBytesKeyAsyncTest(
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
            await ms.ToKmac256StringAsync(keyBytes, outputLength, customizationBytes),
            result
        );
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public async Task StreamToKmac256MemoryWithBytesKeyAsyncTest(
        string source,
        string key,
        string customization,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var customizationBytes = customization.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);

        var memory = new Memory<byte>(new byte[64]);
        ms.TrySeek(0, SeekOrigin.Begin);
        await ms.ToKmac256Async(keyBytes, memory, customizationBytes);
        Assert.Equal(memory.ToArray().ToHexString(), result);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        64,
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public async Task StreamToKmac256BytesWithMemoryKeyAsyncTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var keyMemory = new ReadOnlyMemory<byte>(keyBytes);
        var customizationBytes = customization.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);

        Assert.Equal(
            (await ms.ToKmac256Async(keyMemory, outputLength, customizationBytes)).ToHexString(),
            result
        );
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        64,
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public async Task StreamToKmac256StringWithMemoryKeyAsyncTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var keyMemory = new ReadOnlyMemory<byte>(keyBytes);
        var customizationBytes = customization.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);

        Assert.Equal(
            await ms.ToKmac256StringAsync(keyMemory, outputLength, customizationBytes),
            result
        );
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public async Task StreamToKmac256MemoryWithMemoryKeyAsyncTest(
        string source,
        string key,
        string customization,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);

        var keyBytes = key.GetUtf8Bytes();
        var keyMemory = new ReadOnlyMemory<byte>(keyBytes);

        var customizationBytes = customization.GetUtf8Bytes();

        var memorySpan = new Memory<byte>(new byte[64]);
        ms.TrySeek(0, SeekOrigin.Begin);
        await ms.ToKmac256Async(keyMemory, memorySpan, customizationBytes);
        Assert.Equal(memorySpan.ToArray().ToHexString(), result);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        64,
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public void BytesToKmac256BytesWithBytesKeyTest(
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
        var hash = result.FromHex();

        Assert.True(
            bytes.ToKmac256(keyBytes, outputLength, customizationBytes).SequenceEqual(hash)
        );
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        64,
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public void ReadOnlySpanToKmac256BytesWithBytesKeyTest(
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
        var hash = result.FromHex();

        Assert.True(
            readOnlySpan.ToKmac256(keyBytes, outputLength, customizationBytes).SequenceEqual(hash)
        );
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        64,
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public void StreamToKmac256BytesWithBytesKeyTest(
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
        var hash = result.FromHex();

        Assert.True(ms.ToKmac256(keyBytes, outputLength, customizationBytes).SequenceEqual(hash));
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        64,
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public void StringToKmac256BytesWithBytesKeyTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var keyBytes = key.GetUtf8Bytes();
        var customizationBytes = customization.GetUtf8Bytes();
        var hash = result.FromHex();

        Assert.True(
            source.ToKmac256(keyBytes, outputLength, customizationBytes).SequenceEqual(hash)
        );
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        64,
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public void ReadOnlySpanToKmac256BytesWithSpanKeyTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var keySpan = new ReadOnlySpan<byte>(keyBytes);
        var customizationBytes = customization.GetUtf8Bytes();
        var readOnlySpan = new ReadOnlySpan<byte>(bytes);
        var hash = result.FromHex();

        Assert.True(
            readOnlySpan.ToKmac256(keySpan, outputLength, customizationBytes).SequenceEqual(hash)
        );
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "",
        64,
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public void StreamToKmac256BytesWithSpanKeyTest(
        string source,
        string key,
        string customization,
        int outputLength,
        string result
    )
    {
        var bytes = source.GetUtf8Bytes();
        var keyBytes = key.GetUtf8Bytes();
        var keySpan = new ReadOnlySpan<byte>(keyBytes);
        var customizationBytes = customization.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        var hash = result.FromHex();

        Assert.True(ms.ToKmac256(keySpan, outputLength, customizationBytes).SequenceEqual(hash));
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public void Kmac256SpanFillWithBytesKeyTest(string source, string key, string result)
    {
        var bytes = source.GetUtf8Bytes();
        var readOnlySpan = new ReadOnlySpan<byte>(bytes);

        var keyBytes = key.GetUtf8Bytes();

        var readOnlySpanResultWitBytesKey = new Span<byte>(new byte[64]);

        readOnlySpan.ToKmac256(keyBytes, readOnlySpanResultWitBytesKey);

        var hash = result.FromHex();

        Assert.Equal(readOnlySpanResultWitBytesKey.ToArray(), hash);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public void Kmac256StreamFillWithBytesKeyTest(string source, string key, string result)
    {
        var bytes = source.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);

        var keyBytes = key.GetUtf8Bytes();
        var msResultWitBytesKey = new Span<byte>(new byte[64]);

        ms.ToKmac256(keyBytes, msResultWitBytesKey);

        var hash = result.FromHex();

        Assert.Equal(msResultWitBytesKey.ToArray(), hash);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public void Kmac256StringFillWithBytesKeyTest(string source, string key, string result)
    {
        var keyBytes = key.GetUtf8Bytes();
        var stringResultWitBytesKey = new Span<byte>(new byte[64]);
        source.ToKmac256(keyBytes, stringResultWitBytesKey);

        var hash = result.FromHex();

        Assert.Equal(stringResultWitBytesKey.ToArray(), hash);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public void Kmac256SpanFillWithSpanKeyTest(string source, string key, string result)
    {
        var bytes = source.GetUtf8Bytes();
        var readOnlySpan = new ReadOnlySpan<byte>(bytes);

        var keyBytes = key.GetUtf8Bytes();
        var keySpan = new ReadOnlySpan<byte>(keyBytes);

        var readOnlySpanResultBySpanKey = new Span<byte>(new byte[64]);

        readOnlySpan.ToKmac256(keySpan, readOnlySpanResultBySpanKey);

        var hash = result.FromHex();

        Assert.Equal(readOnlySpanResultBySpanKey.ToArray(), hash);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public void Kmac256StreamFillWithSpanKeyTest(string source, string key, string result)
    {
        var bytes = source.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);

        var keyBytes = key.GetUtf8Bytes();
        var keySpan = new ReadOnlySpan<byte>(keyBytes);

        var msResultBySpanKey = new Span<byte>(new byte[64]);
        ms.ToKmac256(keySpan, msResultBySpanKey);

        var hash = result.FromHex();

        Assert.Equal(msResultBySpanKey.ToArray(), hash);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "this is a key",
        "CFC5DD48E649CAD2D58E65F4C0F09598A34168AC7D603C1DAFD468E97A584B637D77DE1984221F890153FEFD79F1F5BC8A0E755B312A6589B318BA30526D7A97"
    )]
    public void Kmac256StringFillWithSpanKeyTest(string source, string key, string result)
    {
        var keyBytes = key.GetUtf8Bytes();
        var keySpan = new ReadOnlySpan<byte>(keyBytes);

        var stringResultBySpanKey = new Span<byte>(new byte[64]);

        source.ToKmac256(keySpan, stringResultBySpanKey);

        var hash = result.FromHex();

        Assert.Equal(stringResultBySpanKey.ToArray(), hash);
    }
}
#endif
