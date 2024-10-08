global using System;
global using System.IO;
global using System.Linq;
global using System.Security.Cryptography;
global using System.Text;
global using System.Threading.Tasks;
global using Aoxe.Cryptography.Abstractions;
global using Aoxe.Cryptography.AsymmetricAlgorithm.DSA;
global using Aoxe.Cryptography.AsymmetricAlgorithm.ECDSA;
global using Aoxe.Cryptography.AsymmetricAlgorithm.RSA;
global using Aoxe.Cryptography.HashAlgorithm.MD5;
global using Aoxe.Cryptography.HashAlgorithm.Sha1;
global using Aoxe.Cryptography.HashAlgorithm.SHA1;
global using Aoxe.Cryptography.HashAlgorithm.Sha256;
global using Aoxe.Cryptography.HashAlgorithm.SHA256;
global using Aoxe.Cryptography.HashAlgorithm.Sha384;
global using Aoxe.Cryptography.HashAlgorithm.SHA384;
global using Aoxe.Cryptography.HashAlgorithm.Sha512;
global using Aoxe.Cryptography.SymmetricAlgorithm.AES;
global using Aoxe.Cryptography.SymmetricAlgorithm.DES;
global using Aoxe.Cryptography.SymmetricAlgorithm.RC2;
global using Aoxe.Cryptography.SymmetricAlgorithm.TripleDES;
global using Aoxe.Extensions;
global using Xunit;
#if NET8_0_OR_GREATER
global using Aoxe.Cryptography.HashAlgorithm.SHA3_256;
global using Aoxe.Cryptography.HashAlgorithm.SHA3_384;
global using Aoxe.Cryptography.HashAlgorithm.SHA3_512;
global using Aoxe.Cryptography.HashAlgorithm.Shake128;
global using Aoxe.Cryptography.HashAlgorithm.Shake256;
#endif
#if NET9_0_OR_GREATER
global using Aoxe.Cryptography.HashAlgorithm.Kmac128;
global using Aoxe.Cryptography.HashAlgorithm.Kmac256;
#endif
