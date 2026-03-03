using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServerDomo11G.Server.HTTP;

namespace WebServerDomo11G.Server.Responses
{
    public class TextResponse : ContentResponse
    {
        public TextResponse(string content)
            : base(content, ContentType.PlainText)
        {
        }

        public TextResponse(string content, Action<Request, Response> preRenderAction)
            : base(content, ContentType.PlainText)
        {
            this.PreRenderAction = preRenderAction;
        }
    }

}
