using System;
using System.Text;

namespace PayWall.NetCore.Extensions;

public static class StringExtensions
{
    public static string Base64Decode(this string base64EncodedData)
    {
        return string.IsNullOrEmpty(base64EncodedData) ? string.Empty : Encoding.UTF8.GetString(Convert.FromBase64String(base64EncodedData));
    }
}