using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;
using WebServerDomo11G.Server.Contracts;
using WebServerDomo11G.Server.HTTP.Routing;
using WebServerDomo11G.Server.HTTP;

namespace WebServerDomo11G.Server
{
    public class HttpServer
    {
        private IPAddress ipAddress;
        private int port;
        private TcpListener serverListener;
        private readonly RoutingTable routes;

        public HttpServer(string ipAddress,
            int port,
            Action<IRoutingTable> routingTableConfiguration)
        {
            this.port = port;
            this.ipAddress = IPAddress.Parse(ipAddress);
            serverListener = new TcpListener(this.ipAddress, this.port);

            routingTableConfiguration(this.routes = new RoutingTable());
        }


        public HttpServer(int port, Action<IRoutingTable> routingTable)
            : this("127.0.0.1", port, routingTable)
        {

        }

        public void Start()
        {
            serverListener.Start();

            Console.WriteLine($"Server started on port {port}");
            Console.WriteLine("Listening for requests...");
            while (true)
            {
                var connection = serverListener.AcceptTcpClient();
                var networkStream = connection.GetStream();
                var requestString = ReadRequest(networkStream);
                Console.WriteLine(requestString);
                var request = Request.Parse(requestString);
                var response = routes.MatchRequest(request);

                WriteResponse(networkStream, response);

                connection.Close();
            }

        }

        private void WriteResponse(NetworkStream networkStream, Response response)
        {
            networkStream.Write(Encoding.UTF8.GetBytes(response.ToString()));

        }

        private string ReadRequest(NetworkStream networkStream)
        {
            var bufferLength = 1024;
            var buffer = new byte[bufferLength];

            var totalbytes = 0;
            var requestBuilder = new StringBuilder();

            do
            {
                var bytesRead = networkStream.Read(buffer, 0, bufferLength);
                if (bytesRead == 0) break;
                totalbytes += bytesRead;
                if (totalbytes > 10 * bufferLength)
                {
                    throw new InvalidOperationException("The request is too long");
                }
                requestBuilder.Append(Encoding.UTF8.GetString(buffer, 0, bytesRead));
            }
            while (networkStream.DataAvailable);
            return requestBuilder.ToString();
        }
    }
}