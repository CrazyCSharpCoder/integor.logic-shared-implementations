using Microsoft.Extensions.DependencyInjection;

using IntegorAspHelpers.Http;
using IntegorAspHelpers.MicroservicesInteraction.Authorization;

using IntegorSharedAspHelpers.Http;
using IntegorSharedAspHelpers.MicroservicesInteraction.Authorization;

using ExtensibleRefreshJwtAuthentication;
using ExtensibleRefreshJwtAuthentication.Access.Tokens;
using ExtensibleRefreshJwtAuthentication.Refresh.Tokens;

using ExtensibleJwtAuthenticationTokensImplementations;
using ExtensibleJwtAuthenticationTokensImplementations.Access;
using ExtensibleJwtAuthenticationTokensImplementations.Refresh;

using IntegorLogicShared.IntegorServices.Authorization;

namespace IntegorServiceConfiguration
{
	public static class InfrastructureServicesExtensions
	{
		public static IServiceCollection AddHttpContextServices(this IServiceCollection services)
		{
			services.AddHttpContextAccessor();
			services.AddScoped<IHttpContextProcessedMarker, HttpContextProcessedMarker>();

			return services;
		}

		public static IServiceCollection AddAuthenticationTokensProcessing(this IServiceCollection services)
		{
			services.AddScoped<IProcessRequestAccessTokenAccessor, ProcessRequestAccessTokenCookieAccessor>();
			services.AddScoped<IProcessRequestRefreshTokenAccessor, ProcessRequestRefreshTokenCookieAccessor>();

			return services;
		}

		public static IServiceCollection AddAuthenticationServices(this IServiceCollection services)
		{
			services.AddSingleton<IClaimTypesNamer, StandardClaimTypesNamer>();
			services.AddSingleton<IUserClaimsParser, StandardUserClaimsParser>();

			services.AddScoped<IUserCachingService, StandardUserCachingService>();

			services.AddSingleton<UserRolesEnumConverter>();

			return services;
		}
	}
}
