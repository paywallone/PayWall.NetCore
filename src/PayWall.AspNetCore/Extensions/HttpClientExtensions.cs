using System.Net.Http;

namespace PayWall.AspNetCore.Extensions;

public static class HttpClientExtensions
{
    public static void SetHeader(this HttpClient client, string headerName, string headerValue)
    {
        if (client.DefaultRequestHeaders.Contains(headerName))
        {
            client.DefaultRequestHeaders.Remove(headerName);
        }

        client.DefaultRequestHeaders.Add(headerName, headerValue);
    }
}
