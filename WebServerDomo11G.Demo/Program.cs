using WebServerDomo11G.Server;
using WebServerDomo11G.Server.Responses;
using WebServerDomo11G.Server.HTTP;

namespace WebServerDomo11G.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var server = new HttpServer(5000, routes =>
            {
                routes.MapGet("/", new HtmlResponse("<h1>Home</h1><p>Welcome to WebServerDomo11G</p>"));
                routes.MapGet("/text", new TextResponse("Plain text response"));
                routes.MapGet("/redirect", new RedirectResponse("/"));
            });

            server.Start();
        }
    }
}