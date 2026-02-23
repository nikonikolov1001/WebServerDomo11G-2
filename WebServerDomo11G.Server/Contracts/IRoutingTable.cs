using System;
using WebServerDomo11G.Server.HTTP;

namespace WebServerDomo11G.Server.Contracts
{
    public interface IRoutingTable
    {
        IRoutingTable Map(string url, Method method, Response response);
        IRoutingTable MapGet(string url, Response response);
        IRoutingTable MapPost(string url, Response response);

        Response MatchRequest(Request request);
    }
}