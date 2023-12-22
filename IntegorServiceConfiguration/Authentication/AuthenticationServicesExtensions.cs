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

using IntegorAspHelpers.MicroservicesInteraction.Authorization.Claims;
using IntegorAspHelpers.MicroservicesInteraction.Authorization.Filters;
using IntegorAspHelpers.MicroservicesInteraction.Authorization.Filters.Internal;

using IntegorSharedAspHelpers.MicroservicesInteraction.Authorization.Claims;

namespace IntegorServiceConfiguration.Authentication
{
	public static class AuthenticationServicesExtensions
	{
		public static IServiceCollection AddOnServiceProcessingTokenAuthentication(this IServiceCollection services)
		{
			services.AddScoped<IOnServiceProcessingAccessTokenAccessor, OnServiceProcessingAccessTokenCookieAccessor>();
			services.AddScoped<IOnServiceProcessingRefreshTokenAccessor, OnServiceProcessingRefreshTokenCookieAccessor>();

			return services;
		}

		public static IServiceCollection AddAuthenticationValidation(this IServiceCollection services)
		{
			services.AddScoped<IClaimsValidator, StandardClaimsValidator>();
			services.AddScoped<ValidateUserAuthenticationLogic>();
			services.AddScoped<ValidateUserAuthenticationAttribute>();

			return services;
		}
	}
}
