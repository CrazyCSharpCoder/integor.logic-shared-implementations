using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using IntegorGlobalConstants;
using ExtensibleRefreshJwtAuthentication.Access;

namespace ExtensibleJwtAuthenticationTokensImplementations.Access
{
    using Internal;

    public class OnServiceProcessingAccessTokenCookieAccessor : IOnServiceProcessingAccessTokenAccessor
    {
        private HttpContext _http;

        public OnServiceProcessingAccessTokenCookieAccessor(IHttpContextAccessor http)
        {
            _http = http.HttpContext;
        }

        public void AttachToResponse(string token)
        {
            _http.Response.Cookies.AttachCookieToken(HttpConstants.AccessTokenCookieName, token);
        }

        public string? GetFromRequest()
        {
            _http.Request.Cookies.TryGetValue(HttpConstants.AccessTokenCookieName, out string token);
            return token;
        }
    }
}
