using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using ExtensibleRefreshJwtAuthentication.Access;
using ExtensibleRefreshJwtAuthentication.Refresh;

using ExtensibleJwtAuthenticationTokensImplementations.Access;
using ExtensibleJwtAuthenticationTokensImplementations.Refresh;

namespace IntegorServiceConfiguration.Authentication
{
	public static class AuthenticationServicesExtensions
	{
		public static IServiceCollection AddAuthenticationTokensProcessing(this IServiceCollection services)
		{
			services.AddScoped<IOnServiceProcessingAccessTokenAccessor, OnServiceProcessingAccessTokenCookieAccessor>();
			services.AddScoped<IOnServiceProcessingRefreshTokenAccessor, OnServiceProcessingRefreshTokenCookieAccessor>();

			return services;
		}
	}
}
