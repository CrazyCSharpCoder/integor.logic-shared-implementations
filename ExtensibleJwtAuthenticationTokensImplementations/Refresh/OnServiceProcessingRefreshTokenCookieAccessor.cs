using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using IntegorGlobalConstants;
using ExtensibleRefreshJwtAuthentication.Refresh;

namespace ExtensibleJwtAuthenticationTokensImplementations.Refresh
{
    using Internal;

    public class OnServiceProcessingRefreshTokenCookieAccessor : IOnServiceProcessingRefreshTokenAccessor
    {
        private HttpContext _http;

        public OnServiceProcessingRefreshTokenCookieAccessor(IHttpContextAccessor http)
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
