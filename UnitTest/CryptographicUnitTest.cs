using System;
using System.Text;
using Xunit;
using Zaabee.Cryptographic;

namespace UnitTest
{
    public class CryptographicUnitTest
    {
        [Fact]
        public void CaiNiaoTest()
        {
            var key = "key123";
            var content = "hello1234" + key;
            var bytes = Encoding.UTF8.GetBytes(content);
            var result = bytes.Md5().ToBase64();

            Assert.Equal("ufYU7rvXhHY3IDyZgyt6SA==", result);
        }

        [Theory]
        [InlineData("apple", false, false, "274f6c49b3e31a0c")]
        [InlineData("apple", false, true, "27-4f-6c-49-b3-e3-1a-0c")]
        [InlineData("apple", true, false, "274F6C49B3E31A0C")]
        [InlineData("apple", true, true, "27-4F-6C-49-B3-E3-1A-0C")]
        public void To16Md5Test(string str, bool isUpper, bool isIncludeHyphen, string result)
        {
            Assert.Equal(str.To16Md5(isUpper, isIncludeHyphen), result);
        }

        [Theory]
        [InlineData("apple", false, false, "1f3870be274f6c49b3e31a0c6728957f")]
        [InlineData("apple", false, true, "1f-38-70-be-27-4f-6c-49-b3-e3-1a-0c-67-28-95-7f")]
        [InlineData("apple", true, false, "1F3870BE274F6C49B3E31A0C6728957F")]
        [InlineData("apple", true, true, "1F-38-70-BE-27-4F-6C-49-B3-E3-1A-0C-67-28-95-7F")]
        public void To32Md5Test(string str, bool isUpper, bool isIncludeHyphen, string result)
        {
            Assert.Equal(str.To32Md5(isUpper, isIncludeHyphen), result);
        }

        [Theory]
        [InlineData(null)]
        public void To32Md5TestForNull(string str)
        {
            Assert.Throws<ArgumentNullException>(() => str.To32Md5(false));
        }

        [Theory]
        [InlineData("apple", false, false, "d0be2dc421be4fcd0172e5afceea3970e2f3d940")]
        [InlineData("apple", false, true, "d0-be-2d-c4-21-be-4f-cd-01-72-e5-af-ce-ea-39-70-e2-f3-d9-40")]
        [InlineData("apple", true, false, "D0BE2DC421BE4FCD0172E5AFCEEA3970E2F3D940")]
        [InlineData("apple", true, true, "D0-BE-2D-C4-21-BE-4F-CD-01-72-E5-AF-CE-EA-39-70-E2-F3-D9-40")]
        public void Sha1Test(string str, bool isUpper, bool isIncludeHyphen, string result)
        {
            Assert.Equal(str.ToSha1(isUpper, isIncludeHyphen), result);
        }

        [Theory]
        [InlineData("apple", false, false,
            "3a7bd3e2360a3d29eea436fcfb7e44c735d117c42d1c1835420b6b9942dd4f1b")]
        [InlineData("apple", false, true,
            "3a-7b-d3-e2-36-0a-3d-29-ee-a4-36-fc-fb-7e-44-c7-35-d1-17-c4-2d-1c-18-35-42-0b-6b-99-42-dd-4f-1b")]
        [InlineData("apple", true, false,
            "3A7BD3E2360A3D29EEA436FCFB7E44C735D117C42D1C1835420B6B9942DD4F1B")]
        [InlineData("apple", true, true,
            "3A-7B-D3-E2-36-0A-3D-29-EE-A4-36-FC-FB-7E-44-C7-35-D1-17-C4-2D-1C-18-35-42-0B-6B-99-42-DD-4F-1B")]
        public void Sha256Test(string str, bool isUpper, bool isIncludeHyphen, string result)
        {
            Assert.Equal(str.ToSha256(isUpper, isIncludeHyphen), result);
        }

        [Theory]
        [InlineData("apple", false, false,
            "3d8786fcb588c93348756c6429717dc6c374a14f7029362281a3b21dc10250ddf0d0578052749822eb08bc0dc1e68b0f")]
        [InlineData("apple", false, true,
            "3d-87-86-fc-b5-88-c9-33-48-75-6c-64-29-71-7d-c6-c3-74-a1-4f-70-29-36-22-81-a3-b2-1d-c1-02-50-dd-f0-d0-57-80-52-74-98-22-eb-08-bc-0d-c1-e6-8b-0f")]
        [InlineData("apple", true, false,
            "3D8786FCB588C93348756C6429717DC6C374A14F7029362281A3B21DC10250DDF0D0578052749822EB08BC0DC1E68B0F")]
        [InlineData("apple", true, true,
            "3D-87-86-FC-B5-88-C9-33-48-75-6C-64-29-71-7D-C6-C3-74-A1-4F-70-29-36-22-81-A3-B2-1D-C1-02-50-DD-F0-D0-57-80-52-74-98-22-EB-08-BC-0D-C1-E6-8B-0F")]
        public void Sha384Test(string str, bool isUpper, bool isIncludeHyphen, string result)
        {
            Assert.Equal(str.ToSha384(isUpper, isIncludeHyphen), result);
        }

        [Theory]
        [InlineData("apple", false, false,
            "844d8779103b94c18f4aa4cc0c3b4474058580a991fba85d3ca698a0bc9e52c5940feb7a65a3a290e17e6b23ee943ecc4f73e7490327245b4fe5d5efb590feb2")]
        [InlineData("apple", false, true,
            "84-4d-87-79-10-3b-94-c1-8f-4a-a4-cc-0c-3b-44-74-05-85-80-a9-91-fb-a8-5d-3c-a6-98-a0-bc-9e-52-c5-94-0f-eb-7a-65-a3-a2-90-e1-7e-6b-23-ee-94-3e-cc-4f-73-e7-49-03-27-24-5b-4f-e5-d5-ef-b5-90-fe-b2")]
        [InlineData("apple", true, false,
            "844D8779103B94C18F4AA4CC0C3B4474058580A991FBA85D3CA698A0BC9E52C5940FEB7A65A3A290E17E6B23EE943ECC4F73E7490327245B4FE5D5EFB590FEB2")]
        [InlineData("apple", true, true,
            "84-4D-87-79-10-3B-94-C1-8F-4A-A4-CC-0C-3B-44-74-05-85-80-A9-91-FB-A8-5D-3C-A6-98-A0-BC-9E-52-C5-94-0F-EB-7A-65-A3-A2-90-E1-7E-6B-23-EE-94-3E-CC-4F-73-E7-49-03-27-24-5B-4F-E5-D5-EF-B5-90-FE-B2")]
        public void Sha512Test(string str, bool isUpper, bool isIncludeHyphen, string result)
        {
            Assert.Equal(str.ToSha512(isUpper, isIncludeHyphen), result);
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
            Assert.Equal(str, decrypt);
        }
    }
}