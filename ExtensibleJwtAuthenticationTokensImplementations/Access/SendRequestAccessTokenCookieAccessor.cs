using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;

using IntegorGlobalConstants;

using ExtensibleRefreshJwtAuthentication.TokenServices;
using ExtensibleRefreshJwtAuthentication.Access.Tokens;

namespace ExtensibleJwtAuthenticationTokensImplementations.Access
{
    using Internal;

    public class SendRequestAccessTokenCookieAccessor : ISendRequestAccessTokenAccessor
    {
        public NetHttpRequestContext AttachToRequest(string baseAddress, HttpContent httpContent, string token)
            => SendRequestTokenAccessorInternal.AttachCookieTokenToRequest(baseAddress, httpContent, HttpConstants.AccessTokenCookieName, token);

        public string? GetFromResponse(HttpResponseMessage response)
            => SendRequestTokenAccessorInternal.GetFromResponse(response, HttpConstants.AccessTokenCookieName);
    }
}
