using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http.Headers;

using Microsoft.Net.Http.Headers;
using Microsoft.AspNetCore.Http;

namespace ExtensibleJwtAuthenticationTokensImplementations.Internal.TokensAccess
{
	internal static class CookieTokensHelpers
	{
		public static void AttachCookieToken(this IResponseCookies cookies, string cookieName, string token)
		{
			CookieOptions options = new CookieOptions()
			{
				HttpOnly = true
				// TODO make secure
			};
			cookies.Append(cookieName, token, options);
		}
	}
}
