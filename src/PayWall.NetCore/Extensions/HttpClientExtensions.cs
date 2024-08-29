using System.Net.Http;

namespace PayWall.NetCore.Extensions;

public static class HttpClientExtensions
{
    public static void SetHeader(this HttpClient client, string headerName, string headerValue)
    {
        if (client.DefaultRequestHeaders.Contains(headerName))
        {
            client.DefaultRequestHeaders.Remove(headerName);
        }

        if (!string.IsNullOrEmpty(headerValue))
        {
            client.DefaultRequestHeaders.Add(headerName, headerValue);
        }        
    }
}
