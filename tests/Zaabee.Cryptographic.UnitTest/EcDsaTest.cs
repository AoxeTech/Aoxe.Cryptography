using System;
using System.Security.Cryptography;
using System.Text;
using Xunit;

namespace Zaabee.Cryptographic.UnitTest
{
    public class EcDsaTest
    {
        [Theory]
        [InlineData("Here is some data to encrypt!", "MD5")]
        [InlineData("Here is some data to encrypt!", "SHA1")]
        [InlineData("Here is some data to encrypt!", "SHA256")]
        [InlineData("Here is some data to encrypt!", "SHA384")]
        [InlineData("Here is some data to encrypt!", "SHA512")]
        public void BytesDataTest(string original, string hashAlgorithmName)
        {
            var hashAlgorithm = GetHashAlgorithmName(hashAlgorithmName);
            var (privateKey, publicKey) = EcdsaHelper.GenerateParameters();
            var originalBytes = Encoding.UTF8.GetBytes(original);
            var signBytes = EcdsaHelper.SignData(originalBytes, privateKey, hashAlgorithm);
            Assert.True(EcdsaHelper.VerifyData(originalBytes, signBytes, publicKey, hashAlgorithm));
        }

        [Theory]
        [InlineData("Here is some data to encrypt!", "MD5")]
        [InlineData("Here is some data to encrypt!", "SHA1")]
        [InlineData("Here is some data to encrypt!", "SHA256")]
        [InlineData("Here is some data to encrypt!", "SHA384")]
        [InlineData("Here is some data to encrypt!", "SHA512")]
        public void StringDataTest(string original, string hashAlgorithmName)
        {
            var hashAlgorithm = GetHashAlgorithmName(hashAlgorithmName);
            var (privateKey, publicKey) = EcdsaHelper.GenerateParameters();
            var signBytes = EcdsaHelper.SignData(original, privateKey, hashAlgorithm);
            Assert.True(EcdsaHelper.VerifyData(original, signBytes, publicKey, hashAlgorithm));
        }

        [Theory]
        [InlineData("Here is some data to encrypt!")]
        public void BytesHashTest(string original)
        {
            var (privateKey, publicKey) = EcdsaHelper.GenerateParameters();
            var originalBytes = Encoding.UTF8.GetBytes(original);
            var signBytes = EcdsaHelper.SignHash(originalBytes, privateKey);
            Assert.True(EcdsaHelper.VerifyHash(originalBytes, signBytes, publicKey));
        }

        [Theory]
        [InlineData("Here is some data to encrypt!")]
        public void StringHashTest(string original)
        {
            var (privateKey, publicKey) = EcdsaHelper.GenerateParameters();
            var signBytes = EcdsaHelper.SignHash(original, privateKey);
            Assert.True(EcdsaHelper.VerifyHash(original, signBytes, publicKey));
        }

        private HashAlgorithmName GetHashAlgorithmName(string name)
        {
            switch (name)
            {
                case "MD5": return HashAlgorithmName.MD5;
                case "SHA1": return HashAlgorithmName.SHA1;
                case "SHA256": return HashAlgorithmName.SHA256;
                case "SHA384": return HashAlgorithmName.SHA384;
                case "SHA512": return HashAlgorithmName.SHA512;
                default: throw new ArgumentOutOfRangeException();
            }
        }
    }
}