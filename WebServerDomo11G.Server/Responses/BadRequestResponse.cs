using System;
using WebServerDomo11G.Server.HTTP;

namespace WebServerDomo11G.Server.Responses
{
    public class BadRequestResponse : Response
    {
        public BadRequestResponse()
            : base(StatusCode.BadRequest)
        {
        }
    }
}