using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Net;
using System.Net.Http;

using Microsoft.Net.Http.Headers;

using ExtensibleRefreshJwtAuthentication.TokenServices;

namespace ExtensibleJwtAuthenticationTokensImplementations.Internal
{
    internal static class SendRequestTokenAccessorInternal
    {
        public static NetHttpRequestContext AttachCookieTokenToRequest(string baseAddress, HttpContent httpContent, string tokenCookieName, string token)
        {
            Uri baseUri = new Uri(baseAddress);
            Dictionary<string, string> cookies = CookieHelpers.CreateTokenCookieDictionary(tokenCookieName, token);

            CookieContainer cookieContainer = NetHttpHelpers.CreateCookieContainer(baseUri, cookies);
            HttpClientHandler clientHandler = NetHttpHelpers.CreateHttpClientHandler(cookieContainer);

            HttpClient httpClient = new HttpClient(clientHandler) { BaseAddress = baseUri };

            return new NetHttpRequestContext(httpClient, clientHandler);
        }

        public static string? GetFromResponse(HttpResponseMessage response, string cookieTokenName)
        {
            if (!response.Headers.TryGetValues(HeaderNames.SetCookie, out IEnumerable<string>? setCookies))
                return null;

            return setCookies
                .Select(headerValue => CookieHelpers.GetSetCookieValue(headerValue, cookieTokenName))
                .FirstOrDefault(filteredValue => string.IsNullOrEmpty(filteredValue));
        }
    }
}
