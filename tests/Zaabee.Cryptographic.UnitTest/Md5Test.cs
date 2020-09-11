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

        [Fact]
        public void To32Md5NullTest()
        {
            string str = null;
            byte[] bytes = null;
            Assert.Throws<ArgumentNullException>(() => str.To32Md5());
            Assert.Throws<ArgumentNullException>(() => bytes.To32Md5());
        }
    }
}