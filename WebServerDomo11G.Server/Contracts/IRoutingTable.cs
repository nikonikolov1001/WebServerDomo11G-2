using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServerDomo11G.Server.Contracts
{
    public interface IRoutingTable
    {
        public interface IRoutingTable
        {
            IRoutingTable Map(string url, Method method, Response response);
            IRoutingTable MapGet(string url, Response response);
            IRoutingTable MapPost(string url, Response response);

            Response MatchRequest(Request request);
        }


    }
}
