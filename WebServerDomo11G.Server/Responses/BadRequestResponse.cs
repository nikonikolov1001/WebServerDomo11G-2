using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServerDomo11G.Server.HTTP;

public class BadRequestResponse : Response
{
    public BadRequestResponse()
        : base(StatusCode.BadRequest)
    {
    }
}

