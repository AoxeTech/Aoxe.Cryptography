# Zaabee.Cryptographic

The wraps and extension methods of AES/MD5/SHA

    [Theory]
    [InlineData("apple", "274f6c49b3e31a0c")]
    [InlineData("banana", "297a228a75730123")]
    [InlineData("pear", "b1b2534bab7b0372")]
    public void To16Md5Test(string str, string result)
    {
        Assert.Equal(str.To16Md5(false), result);
    }

    [Theory]
    [InlineData("duxiaofei", "e719bdf143ebeda07d268b2fe6848676")]
    [InlineData("apple", "1f3870be274f6c49b3e31a0c6728957f")]
    [InlineData("banana", "72b302bf297a228a75730123efef7c41")]
    [InlineData("pear", "8893dc16b1b2534bab7b03727145a2bb")]
    public void To32Md5Test(string str, string result)
    {
        Assert.Equal(str.To32Md5(false), result);
    }

    [Theory]
    [InlineData(null)]
    public void To32Md5TestForNull(string str)
    {
        Assert.Throws<ArgumentNullException>(() => str.To32Md5(false));
    }

    [Theory]
    [InlineData("apple", "d0be2dc421be4fcd0172e5afceea3970e2f3d940")]
    [InlineData("banana", "250e77f12a5ab6972a0895d290c4792f0a326ea8")]
    [InlineData("pear", "3e2bf5faa2c3fec1f84068a073b7e51d7ad44a35")]
    public void Sha1Test(string str, string result)
    {
        Assert.Equal(str.ToSha1(), result.ToUpper());
    }

    [Theory]
    [InlineData("apple", "3a7bd3e2360a3d29eea436fcfb7e44c735d117c42d1c1835420b6b9942dd4f1b")]
    [InlineData("banana", "b493d48364afe44d11c0165cf470a4164d1e2609911ef998be868d46ade3de4e")]
    [InlineData("pear", "97cfbe87531abe0c6bac7b21d616cb422faaa158a9f2ae7e8685c79eb85fc65e")]
    public void Sha256Test(string str, string result)
    {
        Assert.Equal(str.ToSha256(), result.ToUpper());
    }

    [Theory]
    [InlineData("apple",
        "3d8786fcb588c93348756c6429717dc6c374a14f7029362281a3b21dc10250ddf0d0578052749822eb08bc0dc1e68b0f")]
    [InlineData("banana",
        "92f7818b31b9936b90a5178e811979ef3ba68a14b57e8362424d54446f31ad2a249e4306628ad33ccb28b3e9dc5e043e")]
    [InlineData("pear",
        "ae997e7b27014c4777949e9ad50ebc75f8a79d499fefbbf8a9aa1d0606a36ca228ef5b8cc8085b54faf9655b6f1ab57b")]
    public void Sha384Test(string str, string result)
    {
        Assert.Equal(str.ToSha384(), result.ToUpper());
    }

    [Theory]
    [InlineData("apple",
        "844d8779103b94c18f4aa4cc0c3b4474058580a991fba85d3ca698a0bc9e52c5940feb7a65a3a290e17e6b23ee943ecc4f73e7490327245b4fe5d5efb590feb2")]
    [InlineData("banana",
        "f8e3183d38e6c51889582cb260ab825252f395b4ac8fb0e6b13e9a71f7c10a80d5301e4a949f2783cb0c20205f1d850f87045f4420ad2271c8fd5f0cd8944be3")]
    [InlineData("pear",
        "0feb729ea2a1d6c7eb415e3fa9a297a0e26723daf463e06d6872eae45629e79f1fdd277741f92f5acb3e55611875453e747f9770176d4284eaffe588e31bad3a")]
    public void Sha512Test(string str, string result)
    {
        Assert.Equal(str.ToSha512(), result.ToUpper());
    }

    [Fact]
    public void AesTest()
    {
        const string str = "apple";
        const string key = "sdkfj;lksadjf;aksjdfkjsad";
        const string vector = "01234567890123456789";
        const string vector2 = "01234567890123456";
        var aesHelper = new AesHelper();
        var encrypt = aesHelper.Encrypt(str, key, vector, Encoding.UTF8);
        var decrypt = aesHelper.Decrypt(encrypt, key, vector2, Encoding.UTF8);
        Assert.Equal(str,decrypt);
    }
