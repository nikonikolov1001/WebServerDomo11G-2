using System;
using System.Text;
using WebServerDomo11G.Server.HTTP;

public class Response
{
	public Response(StatusCode statusCode)
	{
	   StatusCode = statusCode;
	   Headers.Add(Header.Server, "My web Server");
	   Headers.Add(Header.Date, $"{DateTime.UtcNow :r}");
	}

	public StatusCode StatusCode {  get; set; }

	public HeaderCollection Headers { get; set; } = new HeaderCollection();

	public string body { get; set; }

    public override string ToString()
    {
		var result = new StringBuilder();

		result.Append($"HTTP/1.1 {(int)StatusCode} {StatusCode}");

		foreach (var header in Headers)
		{
			result.Append($"{header.Name} : {header.Value}");
		}
    }
}
