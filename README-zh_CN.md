# Aoxe.Cryptography

[English](README.md) | 简体中文

---

提供使用加密算法的简便方法。此软件包支持 AES/MD5/SHA/RSA/DSA/ECDSA/DES/TripleDES 的封装和扩展方法

- 对称算法
  - AES
  - DES
  - RC2
  - TripleDES
- 非对称算法
  - DSA
  - ECDSA
  - RSA
- 哈希算法
  - MD5
  - SHA1
  - SHA256
  - SHA384
  - SHA512
  - SHA3-256
  - SHA3-384
  - SHA3-512
  - SHAKE128
  - SHAKE256
  - KMAC128
  - KMAC256

## 1. 快速入门

### 1.1. 安装

```Shell
PM> Install-Package Aoxe.Cryptography
```

### 1.2. MD5

```CSharp
var apple = "apple";
var md5String = apple.ToMd5String();
var md5Bytes = apple.ToMd5();
```

### 1.3. SHA

```CSharp
var apple = "apple";
//D0BE2DC421BE4FCD0172E5AFCEEA3970E2F3D940
var sha1String = apple.ToSha1String();
var sha1Bytes = apple.ToSha1();
//3A7BD3E2360A3D29EEA436FCFB7E44C735D117C42D1C1835420B6B9942DD4F1B
var sha256String = apple.ToSha256String();
var sha256Bytes = apple.ToSha256();
//3D8786FCB588C93348756C6429717DC6C374A14F7029362281A3B21DC10250DDF0D0578052749822EB08BC0DC1E68B0F
var sha384String = apple.ToSha384String();
var sha384Bytes = apple.ToSha384();
//844D8779103B94C18F4AA4CC0C3B4474058580A991FBA85D3CA698A0BC9E52C5940FEB7A65A3A290E17E6B23EE943ECC4F73E7490327245B4FE5D5EFB590FEB2
var sha512String = apple.ToSha512String();
var sha512Bytes = apple.ToSha512();
```

### 1.4. AES

```CSharp
var original = "Here is some data to encrypt!";
var key = AesHelper.GenerateKey();
var vector = AesHelper.GenerateVector();
//Default cipher mode is CBC and padding mode is PKCS7.
var encrypt = original.EncryptByAes(key, vector); // Also you can use Helper like this: AesHelper.Decrypt(encrypt, key, vector);
var decrypt = encrypt.DecryptByAes(key, vector); // Also you can use Helper like this: AesHelper.Decrypt(encrypt, key, vector);
var decryptString = Encoding.UTF8.GetString(decrypt);
```

### 1.5. RC2

```CSharp
var original = "Here is some data to encrypt!";
var key = Rc2Helper.GenerateKey();
var vector = Rc2Helper.GenerateVector();
//Default cipher mode is CBC and padding mode is PKCS7.
var encrypt = original.EncryptByRc2(key, vector); // Also you can use Helper like this: Rc2Helper.Decrypt(encrypt, key, vector);
var decrypt = encrypt.DecryptByRc2(key, vector); // Also you can use Helper like this: Rc2Helper.Decrypt(encrypt, key, vector);
var decryptString = Encoding.UTF8.GetString(decrypt);
```

### 1.6. DES

```CSharp
var original = "Here is some data to encrypt!";
var key = DesHelper.GenerateKey();
var vector = DesHelper.GenerateVector();
//Default cipher mode is CBC and padding mode is PKCS7.
var encrypt = original.EncryptByDes(key, vector); // Also you can use Helper like this: DesHelper.Decrypt(encrypt, key, vector);
var decrypt = encrypt.DecryptByDes(key, vector); // Also you can use Helper like this: DesHelper.Decrypt(encrypt, key, vector);
var decryptString = Encoding.UTF8.GetString(decrypt);
```

### 1.7. TripleDES

```CSharp
var original = "Here is some data to encrypt!";
var key = TripleDesHelper.GenerateKey();
var vector = TripleDesHelper.GenerateVector();
//Default cipher mode is CBC and padding mode is PKCS7.
var encrypt = original.EncryptByTripleDes(key, vector); // Also you can use Helper like this: TripleDesHelper.Decrypt(encrypt, key, vector);
var decrypt = encrypt.DecryptByTripleDes(key, vector); // Also you can use Helper like this: TripleDesHelper.Decrypt(encrypt, key, vector);
var decryptString = Encoding.UTF8.GetString(decrypt);
```

### 1.8. RSA

默认填充为 OaepSHA256，默认编码为 utf8

```CSharp
var original = "Here is some data to encrypt!";
var (privateKey, publicKey) = RsaHelper.GenerateParameters();
var originalBytes = Encoding.UTF8.GetBytes(original);
var encryptBytes = originalBytes.EncryptByRsa(publicKey); // Also you can use Helper like this: RsaHelper.Encrypt(originalBytes, publicKey);
var decryptBytes = encryptBytes.DecryptByRsa(privateKey); // Also you can use Helper like this: RsaHelper.Decrypt(encryptBytes, privateKey);
var decrypt = Encoding.UTF8.GetString(decryptBytes);
Assert.True(original, decrypt);
```

### 1.9. ECDSA

默认编码为 utf8

```CSharp
var original = "Here is some data to encrypt!";
//SignData
var (privateKey, publicKey) = EcdsaHelper.GenerateParameters();
var originalBytes = EcdsaHelper.Encoding.GetBytes(original);
var signBytes = originalBytes.SignDataByEcdsa(privateKey, hashAlgorithm);
//True
var result = originalBytes.VerifyDataByEcdsa(signBytes, publicKey, hashAlgorithm);
```

```CSharp
//SignHash
var (privateKey, publicKey) = EcdsaHelper.GenerateParameters();
var originalBytes = EcdsaHelper.Encoding.GetBytes(original);
var signBytes = originalBytes.SignHashByEcdsa(privateKey);
//True
var result = originalBytes.VerifyHashByEcdsa(signBytes, publicKey);
```

### 1.10. DSA

默认编码为 utf8

```CSharp
var (privateKey, publicKey) = DsaHelper.GenerateParameters();
var originalBytes = DsaHelper.Encoding.GetBytes(original);
var signature = originalBytes.CreateSignatureByDsa(privateKey);
//True
var result = originalBytes.VerifySignatureByDsa(signature, publicKey);
```

Thank`s for [JetBrains](https://www.jetbrains.com/) for the great support in providing assistance and user-friendly environment for my open source projects.

[![JetBrains](https://resources.jetbrains.com/storage/products/company/brand/logos/jb_beam.svg?_gl=1*f25lxa*_ga*MzI3ODk2MjY0LjE2NzA0NjY4MDQ.*_ga_9J976DJZ68*MTY4OTY4NzY5OS4zNC4xLjE2ODk2ODgwMDAuNTMuMC4w)](https://www.jetbrains.com/community/opensource/#support)
