using Microsoft.Extensions.DependencyInjection;

using IntegorSharedResponseDecorators;
using IntegorSharedResponseDecorators.Shared.Decorators;
using IntegorSharedResponseDecorators.Authorization.Decorators;

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
