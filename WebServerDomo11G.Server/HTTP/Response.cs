using System;
using System.Linq;
using System.Text;
using WebServerDomo11G.Server.HTTP;

namespace WebServerDomo11G.Server.HTTP
{
    public class Response
    {
        public Response(StatusCode statusCode)
        {
            StatusCode = statusCode;
            Headers.Add(Header.Server, "My web Server");
            Headers.Add(Header.Date, $"{DateTime.UtcNow:r}");
        }

        public StatusCode StatusCode { get; set; }

        public HeaderCollection Headers { get; set; } = new HeaderCollection();

        public CookieCollection Cookies { get; set; } = new CookieCollection();

        public Action<Request, Response> PreRenderAction { get; set; }

        public string body { get; set; }

        public override string ToString()
        {
            var result = new StringBuilder();

            result.Append($"HTTP/1.1 {(int)StatusCode} {StatusCode}\r\n");

            if (!string.IsNullOrEmpty(body))
            {
                var hasContentLength = Headers.Any(h => string.Equals(h.Name, Header.ContentLength, StringComparison.OrdinalIgnoreCase));
                if (!hasContentLength)
                {
                    var contentLength = Encoding.UTF8.GetByteCount(body).ToString();
                    Headers.Add(Header.ContentLength, contentLength);
                }
            }
            else
            {
                var hasContentLength = Headers.Any(h => string.Equals(h.Name, Header.ContentLength, StringComparison.OrdinalIgnoreCase));
                if (!hasContentLength)
                {
                    Headers.Add(Header.ContentLength, "0");
                }
            }

            foreach (var header in Headers)
            {
                result.Append($"{header.Name}: {header.Value}\r\n");
            }

            foreach (var cookie in Cookies)
            {
                result.Append($"Set-Cookie: {cookie}\r\n");
            }

            result.Append("\r\n");

            if (!string.IsNullOrEmpty(body))
            {
                result.Append(body);
            }

            return result.ToString();
        }
    }
}