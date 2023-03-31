using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using IntegorGlobalConstants;
using ExtensibleRefreshJwtAuthentication.Refresh.Tokens;

namespace ExtensibleJwtAuthenticationTokensImplementations.TokensAccess
{
	using Internal.TokensAccess;

    public class HttpContextRefreshTokenCookieAccessor : IHttpContextRefreshTokenAccessor
    {
        private HttpContext _http;

        public HttpContextRefreshTokenCookieAccessor(IHttpContextAccessor http)
        {
            _http = http.HttpContext;
        }

        public void AttachToResponse(string token)
        {
            _http.Response.Cookies.AttachCookieToken(HttpConstants.RefreshTokenCookieName, token);
        }

        public string? GetFromRequest()
        {
            _http.Request.Cookies.TryGetValue(HttpConstants.RefreshTokenCookieName, out string token);
            return token;
        }
    }
}
