using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebServerDomo11G.Server.HTTP
{
	public enum StatusCode
	{
		OK = 200,
		Found = 301,
		NotFound = 404,
		Unauthorized = 401,
		BadRequest = 400
	}
}
