using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Http;

namespace ExtensibleJwtAuthenticationTokensImplementations.Internal.TokensAccess
{
	internal static class NetHttpHelpers
	{
		public static CookieContainer CreateCookieContainer(Uri targetUrl, Dictionary<string, string> cookies)
		{
			CookieContainer container = new CookieContainer();

			foreach (KeyValuePair<string, string> cookieEntry in cookies)
			{
				// TODO make secure
				Cookie cookie = new Cookie(cookieEntry.Key, cookieEntry.Value)
				{
					Domain = targetUrl.Host,
					HttpOnly = true
				};
				container.Add(cookie);
			}

			return container;
		}

		public static HttpClientHandler CreateHttpClientHandler(CookieContainer? cookieContainer)
		{
			HttpClientHandler handler = new HttpClientHandler();

			if (cookieContainer != null)
				handler.CookieContainer = cookieContainer;

			return handler;
		}
	}
}
