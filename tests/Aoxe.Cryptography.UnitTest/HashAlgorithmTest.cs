namespace Aoxe.Cryptography.UnitTest;

public class HashAlgorithmTest
{
    [Theory]
    [InlineData("apple", "1F3870BE274F6C49B3E31A0C6728957F")]
    public void Md5AlgorithmTest(string str, string result)
    {
        var md5Algorithm = new Md5Algorithm();
        ComputeHashTest(md5Algorithm, str, result);
        ComputeHashStringTest(md5Algorithm, str, result);
    }

#if !NET48
    [Theory]
    [InlineData("apple", "1F3870BE274F6C49B3E31A0C6728957F")]
    public async Task Md5AlgorithmTestAsync(string str, string result)
    {
        var md5Algorithm = new Md5Algorithm();
        await ComputeHashAsyncTest(md5Algorithm, str, result);
    }
#endif

    [Theory]
    [InlineData("apple", "D0BE2DC421BE4FCD0172E5AFCEEA3970E2F3D940")]
    public void Sha1AlgorithmTest(string str, string result)
    {
        var sha1Algorithm = new Sha1Algorithm();
        ComputeHashTest(sha1Algorithm, str, result);
        ComputeHashStringTest(sha1Algorithm, str, result);
    }

#if !NET48
    [Theory]
    [InlineData("apple", "D0BE2DC421BE4FCD0172E5AFCEEA3970E2F3D940")]
    public async Task Sha1AlgorithmTestAsync(string str, string result)
    {
        var sha1Algorithm = new Sha1Algorithm();
        await ComputeHashAsyncTest(sha1Algorithm, str, result);
    }
#endif

    [Theory]
    [InlineData("apple", "3A7BD3E2360A3D29EEA436FCFB7E44C735D117C42D1C1835420B6B9942DD4F1B")]
    public void Sha256AlgorithmTest(string str, string result)
    {
        var sha256Algorithm = new Sha256Algorithm();
        ComputeHashTest(sha256Algorithm, str, result);
        ComputeHashStringTest(sha256Algorithm, str, result);
    }

#if !NET48
    [Theory]
    [InlineData("apple", "3A7BD3E2360A3D29EEA436FCFB7E44C735D117C42D1C1835420B6B9942DD4F1B")]
    public async Task Sha256AlgorithmTestAsync(string str, string result)
    {
        var sha256Algorithm = new Sha256Algorithm();
        await ComputeHashAsyncTest(sha256Algorithm, str, result);
    }
#endif

    [Theory]
    [InlineData(
        "apple",
        "3D8786FCB588C93348756C6429717DC6C374A14F7029362281A3B21DC10250DDF0D0578052749822EB08BC0DC1E68B0F"
    )]
    public void Sha384AlgorithmTest(string str, string result)
    {
        var sha384Algorithm = new Sha384Algorithm();
        ComputeHashTest(sha384Algorithm, str, result);
        ComputeHashStringTest(sha384Algorithm, str, result);
    }

#if !NET48
    [Theory]
    [InlineData(
        "apple",
        "3D8786FCB588C93348756C6429717DC6C374A14F7029362281A3B21DC10250DDF0D0578052749822EB08BC0DC1E68B0F"
    )]
    public async Task Sha384AlgorithmTestAsync(string str, string result)
    {
        var sha384Algorithm = new Sha384Algorithm();
        await ComputeHashAsyncTest(sha384Algorithm, str, result);
    }
#endif

    [Theory]
    [InlineData(
        "apple",
        "844D8779103B94C18F4AA4CC0C3B4474058580A991FBA85D3CA698A0BC9E52C5940FEB7A65A3A290E17E6B23EE943ECC4F73E7490327245B4FE5D5EFB590FEB2"
    )]
    public void Sha512AlgorithmTest(string str, string result)
    {
        var sha512Algorithm = new Sha512Algorithm();
        ComputeHashTest(sha512Algorithm, str, result);
        ComputeHashStringTest(sha512Algorithm, str, result);
    }

#if !NET48
    [Theory]
    [InlineData(
        "apple",
        "844D8779103B94C18F4AA4CC0C3B4474058580A991FBA85D3CA698A0BC9E52C5940FEB7A65A3A290E17E6B23EE943ECC4F73E7490327245B4FE5D5EFB590FEB2"
    )]
    public async Task Sha512AlgorithmTestAsync(string str, string result)
    {
        var sha512Algorithm = new Sha512Algorithm();
        await ComputeHashAsyncTest(sha512Algorithm, str, result);
    }
#endif

    private static void ComputeHashTest(IHashAlgorithm hashAlgorithm, string str, string result)
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        var hash = result.FromHex();
        Assert.True(hashAlgorithm.ComputeHash(bytes).SequenceEqual(hash));
        Assert.True(hashAlgorithm.ComputeHash(ms).SequenceEqual(hash));
        Assert.True(hashAlgorithm.ComputeHash(str).SequenceEqual(hash));
    }

    private static void ComputeHashStringTest(
        IHashAlgorithm hashAlgorithm,
        string str,
        string result
    )
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        Assert.Equal(result, hashAlgorithm.ComputeHashString(bytes));
        Assert.Equal(result, hashAlgorithm.ComputeHashString(ms));
        Assert.Equal(result, hashAlgorithm.ComputeHashString(str));
    }

#if !NET48
    private static async Task ComputeHashAsyncTest(
        IHashAlgorithm hashAlgorithm,
        string str,
        string result
    )
    {
        var bytes = str.GetUtf8Bytes();
        var ms = new MemoryStream(bytes);
        var hashBytes = await hashAlgorithm.ComputeHashAsync(ms);
        var hashString = await hashAlgorithm.ComputeHashStringAsync(ms);
        Assert.True(hashBytes.SequenceEqual(result.FromHex()));
        Assert.Equal(result, hashString);
    }
#endif
}
