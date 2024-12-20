namespace Aoxe.Cryptography.Abstractions.UnitTest;

public class NullHashAlgorithmTests
{
    private readonly NullHashAlgorithm _sut = new();
    private readonly byte[] _testBytes = [1, 2, 3];
    private const string TestString = "test";

    [Fact]
    public void ComputeHash_WithBytes_ReturnsEmptyArray()
    {
        var result = _sut.ComputeHash(_testBytes);
        Assert.Empty(result);
    }

    [Fact]
    public void ComputeHash_WithString_ReturnsEmptyArray()
    {
        var result = _sut.ComputeHash(TestString);
        Assert.Empty(result);
    }

    [Fact]
    public void ComputeHash_WithStream_ReturnsEmptyArray()
    {
        using var stream = new MemoryStream(_testBytes);
        var result = _sut.ComputeHash(stream);
        Assert.Empty(result);
    }

    [Fact]
    public void ComputeHashString_WithBytes_ReturnsEmptyString()
    {
        var result = _sut.ComputeHashString(_testBytes);
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void ComputeHashString_WithString_ReturnsEmptyString()
    {
        var result = _sut.ComputeHashString(TestString);
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public void ComputeHashString_WithStream_ReturnsEmptyString()
    {
        using var stream = new MemoryStream(_testBytes);
        var result = _sut.ComputeHashString(stream);
        Assert.Equal(string.Empty, result);
    }

    [Fact]
    public async Task ComputeHashAsync_WithStream_ReturnsEmptyArray()
    {
        using var stream = new MemoryStream(_testBytes);
        var result = await _sut.ComputeHashAsync(stream);
        Assert.Empty(result);
    }

    [Fact]
    public async Task ComputeHashStringAsync_WithStream_ReturnsEmptyString()
    {
        using var stream = new MemoryStream(_testBytes);
        var result = await _sut.ComputeHashStringAsync(stream);
        Assert.Equal(string.Empty, result);
    }
}
