using System;
using System.Text;
using Xunit;

namespace Zaabee.Cryptographic.UnitTest
{
    public class Md5Test
    {
        [Fact]
        public void Test()
        {
            Md5Helper.Encoding = Encoding.UTF8;
            Assert.Equal(Md5Helper.Encoding, Encoding.UTF8);
        }

        [Theory]
        [InlineData("apple", false, false, 8, "6c49b3e3")]
        [InlineData("apple", false, true, 8, "6c-49-b3-e3")]
        [InlineData("apple", true, false, 8, "6C49B3E3")]
        [InlineData("apple", true, true, 8, "6C-49-B3-E3")]
        [InlineData("apple", false, false, 16, "274f6c49b3e31a0c")]
        [InlineData("apple", false, true, 16, "27-4f-6c-49-b3-e3-1a-0c")]
        [InlineData("apple", true, false, 16, "274F6C49B3E31A0C")]
        [InlineData("apple", true, true, 16, "27-4F-6C-49-B3-E3-1A-0C")]
        [InlineData("apple", false, false, 32, "1f3870be274f6c49b3e31a0c6728957f")]
        [InlineData("apple", false, true, 32, "1f-38-70-be-27-4f-6c-49-b3-e3-1a-0c-67-28-95-7f")]
        [InlineData("apple", true, false, 32, "1F3870BE274F6C49B3E31A0C6728957F")]
        [InlineData("apple", true, true, 32, "1F-38-70-BE-27-4F-6C-49-B3-E3-1A-0C-67-28-95-7F")]
        public void ComputeHashTest(string str, bool isUpper, bool isIncludeHyphen, int resultLength, string result)
        {
            Assert.Equal(str.ToMd5(isUpper, isIncludeHyphen, resultLength: resultLength), result);
        }

        [Fact]
        public void NullTest()
        {
            string str = null;
            byte[] bytes = null;
            Assert.Throws<ArgumentNullException>(() => str.ToMd5());
            Assert.Throws<ArgumentNullException>(() => bytes.ToMd5());
        }

        [Fact]
        public void ArgumentTest()
        {
            var str = "test string.";
            var bytes = Md5Helper.Encoding.GetBytes(str);
            Assert.Throws<ArgumentOutOfRangeException>(() => str.ToMd5(resultLength: 0));
            Assert.Throws<ArgumentOutOfRangeException>(() => str.ToMd5(resultLength: 33));
            Assert.Throws<ArgumentException>(() => bytes.ToMd5(resultLength: 1));
        }
    }
}