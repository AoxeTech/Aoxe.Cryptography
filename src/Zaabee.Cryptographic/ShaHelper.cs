namespace Zaabee.Cryptographic;

/// <summary>
/// SHA helper
/// </summary>
public static class ShaHelper
{
    public static Encoding Encoding { get; set; } = Encoding.UTF8;

    #region SHA1

    /// <summary>
    /// Get SHA1 hash string
    /// </summary>
    /// <param name="str"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static string GetSha1HashString(string str, Encoding encoding = null) =>
        GetSha1HashString((encoding ?? Encoding).GetBytes(str));

    /// <summary>
    /// Get SHA1 hash string
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string GetSha1HashString(byte[] bytes)
    {
        var hashBytes = GetSha1HashBytes(bytes);
        return BitConverter.ToString(hashBytes);
    }

    /// <summary>
    /// Get SHA1 hash bytes
    /// </summary>
    /// <param name="str"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static byte[] GetSha1HashBytes(string str, Encoding encoding = null) =>
        GetSha1HashBytes((encoding ?? Encoding).GetBytes(str));

    /// <summary>
    /// Get SHA1 hash bytes
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public static byte[] GetSha1HashBytes(byte[] bytes)
    {
        using var sha1 = SHA1.Create();
        if (sha1 is null) throw new NotSupportedException(nameof(sha1));
        return sha1.ComputeHash(bytes);
    }

    #endregion

    #region SHA256

    /// <summary>
    /// Get SHA256 hash string
    /// </summary>
    /// <param name="str"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static string GetSha256HashString(string str, Encoding encoding = null) =>
        GetSha256HashString((encoding ?? Encoding).GetBytes(str));

    /// <summary>
    /// Get SHA256 hash string
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string GetSha256HashString(byte[] bytes)
    {
        var hashBytes = GetSha256HashBytes(bytes);
        return BitConverter.ToString(hashBytes);
    }

    /// <summary>
    /// Get SHA256 hash bytes
    /// </summary>
    /// <param name="str"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static byte[] GetSha256HashBytes(string str, Encoding encoding = null) =>
        GetSha256HashBytes((encoding ?? Encoding).GetBytes(str));

    /// <summary>
    /// Get SHA256 hash bytes
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public static byte[] GetSha256HashBytes(byte[] bytes)
    {
        using var sha256 = SHA256.Create();
        if (sha256 is null) throw new NotSupportedException(nameof(sha256));
        return sha256.ComputeHash(bytes);
    }

    #endregion

    #region SHA384

    /// <summary>
    /// Get SHA384 hash string
    /// </summary>
    /// <param name="str"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static string GetSha384HashString(string str, Encoding encoding = null) =>
        GetSha384HashString((encoding ?? Encoding).GetBytes(str));

    /// <summary>
    /// Get SHA384 hash string
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string GetSha384HashString(byte[] bytes)
    {
        var hashBytes = GetSha384HashBytes(bytes);
        return BitConverter.ToString(hashBytes);
    }

    /// <summary>
    /// Get SHA384 hash bytes
    /// </summary>
    /// <param name="str"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static byte[] GetSha384HashBytes(string str, Encoding encoding = null) =>
        GetSha384HashBytes((encoding ?? Encoding).GetBytes(str));

    /// <summary>
    /// Get SHA384 hash bytes
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public static byte[] GetSha384HashBytes(byte[] bytes)
    {
        using var sha384 = SHA384.Create();
        if (sha384 is null) throw new NotSupportedException(nameof(sha384));
        return sha384.ComputeHash(bytes);
    }

    #endregion

    #region SHA512

    /// <summary>
    /// Get SHA512 hash string
    /// </summary>
    /// <param name="str"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static string GetSha512HashString(string str, Encoding encoding = null) =>
        GetSha512HashString((encoding ?? Encoding).GetBytes(str));

    /// <summary>
    /// Get SHA512 hash string
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    public static string GetSha512HashString(byte[] bytes)
    {
        var hashBytes = GetSha512HashBytes(bytes);
        return BitConverter.ToString(hashBytes);
    }

    /// <summary>
    /// Get SHA512 hash bytes
    /// </summary>
    /// <param name="str"></param>
    /// <param name="encoding"></param>
    /// <returns></returns>
    public static byte[] GetSha512HashBytes(string str, Encoding encoding = null) =>
        GetSha512HashBytes((encoding ?? Encoding).GetBytes(str));

    /// <summary>
    /// Get SHA512 hash bytes
    /// </summary>
    /// <param name="bytes"></param>
    /// <returns></returns>
    /// <exception cref="NotSupportedException"></exception>
    public static byte[] GetSha512HashBytes(byte[] bytes)
    {
        using var sha512 = SHA512.Create();
        if (sha512 is null) throw new NotSupportedException(nameof(sha512));
        return sha512.ComputeHash(bytes);
    }

    #endregion
}