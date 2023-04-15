using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Configuration;

using IntegorAspHelpers;
using IntegorAspHelpers.MicroservicesInteraction.Authorization;

using IntegorSharedAspHelpers;
using IntegorSharedAspHelpers.MicroservicesInteraction.Authorization;

using ExtensibleRefreshJwtAuthentication;

using IntegorLogicShared.IntegorServices.Authorization;

namespace IntegorServiceConfiguration
{
	public static class InfrastructureServicesExtensions
	{
		/// <param name="claimExtendedTypesConfiguration">Configuration file where ClaimTypeNames values are stored</param>
		public static IServiceCollection AddAuthorizationServices(this IServiceCollection services, IConfiguration claimExtendedTypesConfiguration)
		{
			services.Configure<ExtendedClaimTypesNames>(claimExtendedTypesConfiguration);
			services.Configure<ClaimTypeNames>(claimExtendedTypesConfiguration);

			services.AddScoped<IUserClaimsParser, StandardUserClaimsParser>();
			services.AddScoped<IUserCachingService, StandardUserCachingService>();

			services.AddSingleton<UserRolesEnumConverter>();

			return services;
		}

		public static IServiceCollection AddStatusCodeResponseBodyFactory(this IServiceCollection services)
		{
			return services.AddSingleton<IStatusCodeResponseBodyFactory, StandardStatusCodeResponseBodyFactory>();
		}

		public static IServiceCollection AddStatusCodeResponseBodyFactory<TStatusCodeToBody>(this IServiceCollection services)
			where TStatusCodeToBody : class, IStatusCodeResponseBodyFactory
		{
			return services.AddSingleton<IStatusCodeResponseBodyFactory, TStatusCodeToBody>();
		}
	}
}
