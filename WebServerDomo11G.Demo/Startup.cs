using System;
using System.Text;
using System.Linq;
using WebServerDomo11G.Server;
using WebServerDomo11G.Server.HTTP;
using WebServerDomo11G.Server.Responses;
using WebServerDomo11G.Server.HTTP.Routing;
using WebServerDomo11G.Server.Contracts;

namespace WebServerDomo11G.Demo
{
    public class Startup
    {
        public void Configure(IRoutingTable routes)
        {
            routes.MapGet("/", new HtmlResponse("<h1>Home</h1><p>Welcome to WebServerDomo11G</p>"));
            routes.MapGet("/text", new TextResponse("Plain text response"));
            routes.MapGet("/redirect", new RedirectResponse("/"));

            routes.MapGet("/Cookies", new HtmlResponse("<h1>Cookies</h1>", AddCookiesAction));

            routes.MapGet("/Session", new TextResponse(string.Empty, DisplaySessionInfoAction));
        }

        public void AddCookiesAction(Request request, Response response)
        {
            var bodyBuilder = new StringBuilder();

            var hasOtherCookies = request.Cookies != null &&
                                  request.Cookies.Any(c => !string.Equals(c.Name, Session.SessionCookieName, System.StringComparison.OrdinalIgnoreCase));

            if (hasOtherCookies)
            {
                bodyBuilder.Append("<h1>Cookies</h1><ul>");
                foreach (var cookie in request.Cookies)
                {
                    if (string.Equals(cookie.Name, Session.SessionCookieName, System.StringComparison.OrdinalIgnoreCase))
                        continue;

                    bodyBuilder.Append($"<li>{cookie.Name} = {cookie.Value}</li>");
                }
                bodyBuilder.Append("</ul>");
            }
            else
            {
                bodyBuilder.Append("<h1>Cookies</h1><p>No cookies yet!</p>");
            }

            response.body = bodyBuilder.ToString();

            if (!hasOtherCookies)
            {
                response.Cookies.Add("VisitorId", System.Guid.NewGuid().ToString());
                response.Cookies.Add("LastVisit", System.DateTime.UtcNow.ToString("o"));
            }
        }

        public void DisplaySessionInfoAction(Request request, Response response)
        {
            var hadSessionCookie = request.Cookies != null && request.Cookies.Contains(Session.SessionCookieName);

            if (!hadSessionCookie)
            {
                response.body = "Current date stored!";
            }
            else
            {
                if (request.Session != null && request.Session.ContainsKey(Session.SessionCurrentDateKey))
                {
                    response.body = $"Session created at: {request.Session[Session.SessionCurrentDateKey]}";
                }
                else
                {
                    response.body = "No session date stored.";
                }
            }
        }
    }
}
