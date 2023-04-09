using System.Collections.Generic;
using System.Text.Json;

using Microsoft.Extensions.DependencyInjection;

using IntegorErrorsHandling;
using IntegorSharedErrorHandlers;

using IntegorAspHelpers.MicroservicesInteraction;
using IntegorSharedAspHelpers.MicroservicesInteraction;

using IntegorResponseDecoration.Parsing;
using IntegorSharedResponseDecorators.Shared.Parsers;

namespace IntegorServiceConfiguration.IntegorServicesInteraction
{
	public static class IntegorMicroservicesInteractionServicesExtensions
	{
		public static IServiceCollection AddIntegorServicesJsonErrorsParsing(this IServiceCollection services)
		{
			services.AddSingleton<IErrorParser<JsonError, JsonElement>, JsonErrorParser>();
			services.AddSingleton<IHttpErrorsObjectParser<JsonElement>, StandardJsonHttpErrorsObjectParser>();

			services.AddSingleton<IDecoratedObjectParser<IEnumerable<IResponseError>, JsonElement>, JsonDecoratedErrorsParser>();

			return services;
		}

		public static IServiceCollection AddServicesErrorsToActionResultTranslation(this IServiceCollection services)
		{
			return services.AddSingleton<IServiceErrorsToActionResultTranslator, StandardServiceErrorsToActionResultTranslator>();
		}
	}
}
