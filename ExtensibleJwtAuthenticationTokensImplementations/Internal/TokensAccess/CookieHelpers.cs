using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ExtensibleJwtAuthenticationTokensImplementations.Internal.TokensAccess
{
	internal static class CookieHelpers
	{
		public static string? GetSetCookieValue(string setCookieString, string cookieName)
		{
			string[] setCookieEqualityParts = setCookieString
				.Split('=', 2)
				.ToArray();

			string cookieActualName = setCookieEqualityParts[0].Trim(' ', '"');
			string cookieOptionsString = setCookieEqualityParts[1];

			if (cookieActualName != cookieName)
				return null;

			return cookieOptionsString.Split(';', 2).First().Trim();
		}

		public static Dictionary<string, string> CreateTokenCookieDictionary(string tokenCookieName, string token)
			=> new Dictionary<string, string>() { { tokenCookieName, token } };
	}
}
