using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Xunit;

namespace Zaabee.Cryptographic.UnitTest
{
    public class ShaTest
    {
        [Fact]
        public void Test()
        {
            ShaHelper.Encoding = Encoding.UTF8;
            Assert.Equal(ShaHelper.Encoding, Encoding.UTF8);
        }

        [Theory]
        [InlineData("apple", "D0-BE-2D-C4-21-BE-4F-CD-01-72-E5-AF-CE-EA-39-70-E2-F3-D9-40")]
        public void Sha1StringTest(string str, string result)
        {
            Assert.Equal(str.ToSha1String(), result);
        }

        [Theory]
        [InlineData("apple", "D0-BE-2D-C4-21-BE-4F-CD-01-72-E5-AF-CE-EA-39-70-E2-F3-D9-40")]
        public void Sha1BytesTest(string str, string result)
        {
            Assert.True(str.ToSha1Bytes().SequenceEqual(HexToBytes(result)));
        }

        [Theory]
        [InlineData("apple",
            "3A-7B-D3-E2-36-0A-3D-29-EE-A4-36-FC-FB-7E-44-C7-35-D1-17-C4-2D-1C-18-35-42-0B-6B-99-42-DD-4F-1B")]
        public void Sha256StringTest(string str, string result)
        {
            Assert.Equal(str.ToSha256String(), result);
        }

        [Theory]
        [InlineData("apple",
            "3A-7B-D3-E2-36-0A-3D-29-EE-A4-36-FC-FB-7E-44-C7-35-D1-17-C4-2D-1C-18-35-42-0B-6B-99-42-DD-4F-1B")]
        public void Sha256BytesTest(string str, string result)
        {
            Assert.True(str.ToSha256Bytes().SequenceEqual(HexToBytes(result)));
        }

        [Theory]
        [InlineData("apple",
            "3D-87-86-FC-B5-88-C9-33-48-75-6C-64-29-71-7D-C6-C3-74-A1-4F-70-29-36-22-81-A3-B2-1D-C1-02-50-DD-F0-D0-57-80-52-74-98-22-EB-08-BC-0D-C1-E6-8B-0F")]
        public void Sha384StringTest(string str, string result)
        {
            Assert.Equal(str.ToSha384String(), result);
        }

        [Theory]
        [InlineData("apple",
            "3D-87-86-FC-B5-88-C9-33-48-75-6C-64-29-71-7D-C6-C3-74-A1-4F-70-29-36-22-81-A3-B2-1D-C1-02-50-DD-F0-D0-57-80-52-74-98-22-EB-08-BC-0D-C1-E6-8B-0F")]
        public void Sha384BytesTest(string str, string result)
        {
            Assert.True(str.ToSha384Bytes().SequenceEqual(HexToBytes(result)));
        }

        [Theory]
        [InlineData("apple",
            "84-4D-87-79-10-3B-94-C1-8F-4A-A4-CC-0C-3B-44-74-05-85-80-A9-91-FB-A8-5D-3C-A6-98-A0-BC-9E-52-C5-94-0F-EB-7A-65-A3-A2-90-E1-7E-6B-23-EE-94-3E-CC-4F-73-E7-49-03-27-24-5B-4F-E5-D5-EF-B5-90-FE-B2")]
        public void Sha512StringTest(string str, string result)
        {
            Assert.Equal(str.ToSha512String(), result);
        }

        [Theory]
        [InlineData("apple",
            "84-4D-87-79-10-3B-94-C1-8F-4A-A4-CC-0C-3B-44-74-05-85-80-A9-91-FB-A8-5D-3C-A6-98-A0-BC-9E-52-C5-94-0F-EB-7A-65-A3-A2-90-E1-7E-6B-23-EE-94-3E-CC-4F-73-E7-49-03-27-24-5B-4F-E5-D5-EF-B5-90-FE-B2")]
        public void Sha512BytesTest(string str, string result)
        {
            Assert.True(str.ToSha512Bytes().SequenceEqual(HexToBytes(result)));
        }

        [Fact]
        public void ShaNullTest()
        {
            string str = null;
            byte[] bytes = null;

            Assert.Throws<ArgumentNullException>(() => str.ToSha1String());
            Assert.Throws<ArgumentNullException>(() => bytes.ToSha1String());
            Assert.Throws<ArgumentNullException>(() => str.ToSha256String());
            Assert.Throws<ArgumentNullException>(() => bytes.ToSha256String());
            Assert.Throws<ArgumentNullException>(() => str.ToSha384String());
            Assert.Throws<ArgumentNullException>(() => bytes.ToSha384String());
            Assert.Throws<ArgumentNullException>(() => str.ToSha512String());
            Assert.Throws<ArgumentNullException>(() => bytes.ToSha512String());

            Assert.Throws<ArgumentNullException>(() => str.ToSha1Bytes());
            Assert.Throws<ArgumentNullException>(() => bytes.ToSha1Bytes());
            Assert.Throws<ArgumentNullException>(() => str.ToSha256Bytes());
            Assert.Throws<ArgumentNullException>(() => bytes.ToSha256Bytes());
            Assert.Throws<ArgumentNullException>(() => str.ToSha384Bytes());
            Assert.Throws<ArgumentNullException>(() => bytes.ToSha384Bytes());
            Assert.Throws<ArgumentNullException>(() => str.ToSha512Bytes());
            Assert.Throws<ArgumentNullException>(() => bytes.ToSha512Bytes());
        }

        private static IEnumerable<byte> HexToBytes(string str)
        {
            var arr = str.Split('-');
            var array = new byte[arr.Length];
            for (var i = 0; i < arr.Length; i++) array[i] = Convert.ToByte(arr[i], 16);
            return array;
        }
    }
}