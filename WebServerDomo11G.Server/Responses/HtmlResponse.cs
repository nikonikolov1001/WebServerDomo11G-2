using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServerDomo11G.Server.HTTP;

namespace WebServerDomo11G.Server.Responses
{
    public class HtmlResponse : ContentResponse
    {
        public HtmlResponse(string content)
            : base(content, ContentType.Html)
        {
        }

        public HtmlResponse(string content, Action<Request, Response> preRenderAction)
            : base(content, ContentType.Html)
        {
            this.PreRenderAction = preRenderAction;
        }
    }

}
