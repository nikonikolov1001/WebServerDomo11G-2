using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WebServerDomo11G.Server.Common;

namespace WebServerDomo11G.Server.HTTP
{
    public class ContentResponse : Response
    {
        public ContentResponse(string content, string contentType)
            : base(StatusCode.OK)
        {
            this.body = content;
            this.Headers.Add(Header.ContentType, contentType);
        }

        public override string ToString()
        {
            if (!string.IsNullOrEmpty(this.body))
            {
                this.Headers.Add(
                    Header.ContentLength,
                    Encoding.UTF8.GetByteCount(this.body).ToString());
            }

            return base.ToString();
        }
    }

}
