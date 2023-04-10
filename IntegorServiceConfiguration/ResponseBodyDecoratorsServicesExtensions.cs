using Microsoft.Extensions.DependencyInjection;

using IntegorSharedResponseDecorators.Shared.Decorators;

namespace IntegorServiceConfiguration
{
	public static class ResponseBodyDecoratorsServicesExtensions
	{
		public static IServiceCollection AddResponseDecorators(this IServiceCollection services)
		{
			return services.AddSingleton<ErrorsResponseObjectDecorator>();
		}
	}
}
