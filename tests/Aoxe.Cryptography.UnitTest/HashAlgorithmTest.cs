namespace Aoxe.Cryptography.UnitTest;

public class HashAlgorithmTest
{
    [Theory]
    [InlineData("aoxe", "53F07A4188C9B00265EDE3CE81D64801")]
    public void Md5AlgorithmTest(string str, string result)
    {
        var md5Algorithm = new Md5Algorithm();
        ComputeHashTest(md5Algorithm, str, result);
        ComputeHashStringTest(md5Algorithm, str, result);
    }

#if !NET48
    [Theory]
    [InlineData("aoxe", "53F07A4188C9B00265EDE3CE81D64801")]
    public async Task Md5AlgorithmTestAsync(string str, string result)
    {
        var md5Algorithm = new Md5Algorithm();
        await ComputeHashAsyncTest(md5Algorithm, str, result);
    }
#endif

    [Theory]
    [InlineData("aoxe", "B769BA21C57A0611FD0E6DDC4D9F9A5BE0DEEE9D")]
    public void Sha1AlgorithmTest(string str, string result)
    {
        var sha1Algorithm = new Sha1Algorithm();
        ComputeHashTest(sha1Algorithm, str, result);
        ComputeHashStringTest(sha1Algorithm, str, result);
    }

#if !NET48
    [Theory]
    [InlineData("aoxe", "B769BA21C57A0611FD0E6DDC4D9F9A5BE0DEEE9D")]
    public async Task Sha1AlgorithmTestAsync(string str, string result)
    {
        var sha1Algorithm = new Sha1Algorithm();
        await ComputeHashAsyncTest(sha1Algorithm, str, result);
    }
#endif

    [Theory]
    [InlineData("aoxe", "8B7F4C4B5E13F4546D9ACF863A78542C3EC599E533531A6F081B7EBD8120F288")]
    public void Sha256AlgorithmTest(string str, string result)
    {
        var sha256Algorithm = new Sha256Algorithm();
        ComputeHashTest(sha256Algorithm, str, result);
        ComputeHashStringTest(sha256Algorithm, str, result);
    }

#if !NET48
    [Theory]
    [InlineData("aoxe", "8B7F4C4B5E13F4546D9ACF863A78542C3EC599E533531A6F081B7EBD8120F288")]
    public async Task Sha256AlgorithmTestAsync(string str, string result)
    {
        var sha256Algorithm = new Sha256Algorithm();
        await ComputeHashAsyncTest(sha256Algorithm, str, result);
    }
#endif

    [Theory]
    [InlineData(
        "aoxe",
        "DEC379C8285F01CFE9C07568888D133392299EC25439DC831EE941041FD899DBEB005DCDE56140B7A8CCE578D4A8EE30"
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
        "aoxe",
        "DEC379C8285F01CFE9C07568888D133392299EC25439DC831EE941041FD899DBEB005DCDE56140B7A8CCE578D4A8EE30"
    )]
    public async Task Sha384AlgorithmTestAsync(string str, string result)
    {
        var sha384Algorithm = new Sha384Algorithm();
        await ComputeHashAsyncTest(sha384Algorithm, str, result);
    }
#endif

    [Theory]
    [InlineData(
        "aoxe",
        "1BA1C956B890E58B0F48D98BB66BB05E34B2897967453AE0D7920B3CBC1779C29ECCFE3596F2F12629639FC0D05CE8B5B7E79FB0808F90C3599C08092263985B"
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
        "aoxe",
        "1BA1C956B890E58B0F48D98BB66BB05E34B2897967453AE0D7920B3CBC1779C29ECCFE3596F2F12629639FC0D05CE8B5B7E79FB0808F90C3599C08092263985B"
    )]
    public async Task Sha512AlgorithmTestAsync(string str, string result)
    {
        var sha512Algorithm = new Sha512Algorithm();
        await ComputeHashAsyncTest(sha512Algorithm, str, result);
    }
#endif

#if NET8_0_OR_GREATER

    [Theory]
    [InlineData("aoxe", "A8E39DE774FD3D4A69EDF97E99FA8B6566DD1457F9ABA25E4FCAADD63678C37B")]
    public void Sha3_256AlgorithmTest(string str, string result)
    {
        var sha3256Algorithm = new Sha3_256Algorithm();
        ComputeHashTest(sha3256Algorithm, str, result);
        ComputeHashStringTest(sha3256Algorithm, str, result);
    }

    [Theory]
    [InlineData("aoxe", "A8E39DE774FD3D4A69EDF97E99FA8B6566DD1457F9ABA25E4FCAADD63678C37B")]
    public async Task Sha3_256AlgorithmTestAsync(string str, string result)
    {
        var sha3256Algorithm = new Sha3_256Algorithm();
        await ComputeHashAsyncTest(sha3256Algorithm, str, result);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "24C04A1DD861D48BCB670299D82D90C61001596160E5E71023090389BB823F1527F10B73D00738F8C0E8BBCE63C34A1F"
    )]
    public void Sha3_384AlgorithmTest(string str, string result)
    {
        var sha3384Algorithm = new Sha3_384Algorithm();
        ComputeHashTest(sha3384Algorithm, str, result);
        ComputeHashStringTest(sha3384Algorithm, str, result);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "24C04A1DD861D48BCB670299D82D90C61001596160E5E71023090389BB823F1527F10B73D00738F8C0E8BBCE63C34A1F"
    )]
    public async Task Sha3_384AlgorithmTestAsync(string str, string result)
    {
        var sha3384Algorithm = new Sha3_384Algorithm();
        await ComputeHashAsyncTest(sha3384Algorithm, str, result);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "AE6D6A7AADB3A5CE94DB5068E6AA4BCA470F83563C61FC1BC44B332DD18B406501FAE1E8D14D255E83A22CC33CE970FCDBF8E7A283AA4D530B6ADEA247EF1FE8"
    )]
    public void Sha3_512AlgorithmTest(string str, string result)
    {
        var sha3512Algorithm = new Sha3_512Algorithm();
        ComputeHashTest(sha3512Algorithm, str, result);
        ComputeHashStringTest(sha3512Algorithm, str, result);
    }

    [Theory]
    [InlineData(
        "aoxe",
        "AE6D6A7AADB3A5CE94DB5068E6AA4BCA470F83563C61FC1BC44B332DD18B406501FAE1E8D14D255E83A22CC33CE970FCDBF8E7A283AA4D530B6ADEA247EF1FE8"
    )]
    public async Task Sha3_512AlgorithmTestAsync(string str, string result)
    {
        var sha3512Algorithm = new Sha3_512Algorithm();
        await ComputeHashAsyncTest(sha3512Algorithm, str, result);
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
