using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using IntegorGlobalConstants;

using ExtensibleRefreshJwtAuthentication.TokenServices;
using ExtensibleRefreshJwtAuthentication.Refresh.Tokens;

namespace ExtensibleJwtAuthenticationTokensImplementations.TokensAccess.Refresh
{
	using Internal.TokensAccess;

	public class SendRequestRefreshTokenCookieAccessor : ISendRequestRefreshTokenAccessor
	{
		public NetHttpRequestContext AttachToRequest(string baseAddress, HttpContent httpContent, string token)
			=> SendRequestTokenAccessorInternal.AttachCookieTokenToRequest(baseAddress, httpContent, HttpConstants.RefreshTokenCookieName, token);

		public string? GetFromResponse(HttpResponseMessage response)
			=> SendRequestTokenAccessorInternal.GetFromResponse(response, HttpConstants.RefreshTokenCookieName);
	}
}
