using System.Collections.Generic;
using System.Text.Json;

using Microsoft.Extensions.DependencyInjection;

using IntegorErrorsHandling;

using IntegorResponseDecoration.Parsing;
using IntegorSharedResponseDecorators.Shared.Parsers;

namespace IntegorServiceConfiguration.IntegorServicesInteraction
{
	public static class IntegorMicroservicesInteractionServicesExtensions
	{
		public static IServiceCollection AddIntegorServices(this IServiceCollection services)
		{
			return services.AddSingleton<IDecoratedObjectParser<IEnumerable<IResponseError>, JsonElement>, JsonDecoratedErrorsParser>();
		}
	}
}
