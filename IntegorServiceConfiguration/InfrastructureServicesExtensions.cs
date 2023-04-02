using System;
using System.Net.Sockets;

using Microsoft.EntityFrameworkCore;
using Npgsql;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using IntegorErrorsHandling;
using IntegorErrorsHandling.Filters;
using IntegorErrorsHandling.Converters;

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

using IntegorLogicShared.MicroserviceSpecific.Authorization;

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

		public static IMvcBuilder AddConfiguredControllers(
			this IServiceCollection services, params Type[] exceptionConverters)
		{
			services.AddScoped<SetProcessedFilter>();

			return services.AddControllers(options =>
			{
				options.Filters.Add(new DecorateErrorsResponseAttribute());
				options.Filters.Add(new ExtensibleExeptionHandlingLazyFilterFactory(exceptionConverters));
				options.Filters.Add(new ServiceFilterAttribute(typeof(SetProcessedFilter)));
			})
			.ConfigureApiBehaviorOptions(options =>
			{
				options.InvalidModelStateResponseFactory = OnInvalidModelStateResponse;
			});
		}

		private static IActionResult OnInvalidModelStateResponse(ActionContext context)
		{
			IServiceProvider services = context.HttpContext.RequestServices;

			IErrorConverter<ModelStateDictionary> converter =
				services.GetRequiredService<IErrorConverter<ModelStateDictionary>>();

			IResponseErrorsObjectCompiler errorsCompiler =
				services.GetRequiredService<IResponseErrorsObjectCompiler>();

			IHttpContextProcessedMarker processedMarker =
				services.GetRequiredService<IHttpContextProcessedMarker>();

			IErrorConvertationResult convertResult = converter.Convert(context.ModelState)!;
			object errorBody = errorsCompiler.CompileResponse(convertResult);

			processedMarker.SetProcessed(true);

			return new BadRequestObjectResult(errorBody);
		}
	}
}
