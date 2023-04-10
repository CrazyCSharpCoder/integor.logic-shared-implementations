using System;
using System.Net.Sockets;

using Microsoft.EntityFrameworkCore;
using Npgsql;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Mvc;

using IntegorErrorsHandling.Filters;

using IntegorSharedResponseDecorators.Shared.Attributes;

using IntegorAspHelpers.Http;
using IntegorAspHelpers.Http.Filters;
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
