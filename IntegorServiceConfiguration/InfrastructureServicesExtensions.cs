using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using IntegorAspHelpers.Http;
using IntegorAspHelpers.MicroservicesInteraction.Authorization;

using IntegorSharedAspHelpers.Http;
using IntegorSharedAspHelpers.MicroservicesInteraction.Authorization;

using ExtensibleRefreshJwtAuthentication;
using ExtensibleRefreshJwtAuthentication.Access;
using ExtensibleRefreshJwtAuthentication.Refresh;

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

		/// <param name="claimTypesConfiguration">Configuration file where ClaimTypeNames values are stored</param>
		/// <returns></returns>
		public static IServiceCollection AddAuthorizationServices(this IServiceCollection services, IConfiguration claimTypesConfiguration)
		{
			services.Configure<ClaimTypeNames>(claimTypesConfiguration);
			services.AddScoped<IUserClaimsParser, StandardUserClaimsParser>();

			services.AddScoped<IUserCachingService, StandardUserCachingService>();

			services.AddSingleton<UserRolesEnumConverter>();

			return services;
		}
	}
}
