using System;
using System.Collections.Generic;
using System.Linq;
using WebServerDomo11G.Server.HTTP;

namespace WebServerDomo11G.Server.HTTP
{
    public class Request
    {
        public Method Method { get; set; }

        public string Url { get; set; }

        public HeaderCollection Headers { get; private set; }

        public string Body { get; set; }

        public Dictionary<string, string> FormData { get; private set; } = new Dictionary<string, string>();

        public Action<Request, Response> PreRenderAction { get; set; }

        public static Request Parse(string request)
        {
            var lines = request.Split("\r\n");
            var startLineParts = lines.First().Split(" ");

            var method = ParseMethod(startLineParts[0]);
            var url = startLineParts[1];
            var headers = ParseHeaders(lines.Skip(1));

            var bodyLines = lines.Skip(1 + headers.Count()).ToArray();
            var body = string.Join("\r\n", bodyLines).TrimEnd('\0');

            return new Request()
            {
                Body = body,
                Url = url,
                Method = method,
                Headers = headers,
            };
        }

        public static Method ParseMethod(string method)
        {
            try
            {
                return (Method)Enum.Parse(typeof(Method), method, true);
            }
            catch (Exception)
            {
                throw new InvalidOperationException($"Method {method} is not supported");
            }
        }

        public static HeaderCollection ParseHeaders(IEnumerable<string> headerLines)
        {
            var headerCollection = new HeaderCollection();

            foreach (var line in headerLines)
            {
                if (line == string.Empty)
                {
                    break;
                }
                var headerParts = line.Split(new[] { ':' }, 2);
                if (headerParts.Length != 2)
                {
                    throw new InvalidOperationException("Request is not valid.");
                }

                var headerName = headerParts[0].Trim();
                var headerValue = headerParts[1].Trim();

                headerCollection.Add(headerName, headerValue);
            }
            return headerCollection;
        }
    }
}