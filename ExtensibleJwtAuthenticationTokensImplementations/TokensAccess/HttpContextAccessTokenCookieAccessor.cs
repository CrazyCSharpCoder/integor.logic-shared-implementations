﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Http;

using IntegorGlobalConstants;
using ExtensibleRefreshJwtAuthentication.Access.Tokens;

namespace ExtensibleJwtAuthenticationTokensImplementations.TokensAccess
{
    using Internal.TokensAccess;

    public class HttpContextAccessTokenCookieAccessor : IHttpContextAccessTokenAccessor
	{
        private HttpContext _http;

        public HttpContextAccessTokenCookieAccessor(IHttpContextAccessor http)
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
