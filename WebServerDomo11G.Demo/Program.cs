using WebServerDomo11G.Server;
using WebServerDomo11G.Server.Responses;
using WebServerDomo11G.Server.HTTP;

namespace WebServerDomo11G.Demo
{
    internal class Program
    {
        static void Main(string[] args)
        {
            var startup = new Startup();

            var server = new HttpServer(5000, routes =>
            {
                startup.Configure(routes);
            });

            server.Start();
        }
    }
}