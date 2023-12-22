using Microsoft.Extensions.DependencyInjection;

using IntegorResponseDecoration;
using IntegorSharedResponseDecorators.Shared.Decorators;

namespace IntegorServiceConfiguration
{
	public static class ResponseBodyDecoratorsServicesExtensions
	{
		public static IServiceCollection AddResponseDecorator<TDecorator, TDecoratorImplementation>(this IServiceCollection services)
			where TDecorator : class, IResponseObjectDecorator
			where TDecoratorImplementation : class, TDecorator
		{
			return services.AddSingleton<TDecorator, TDecoratorImplementation>();
		}

		public static IServiceCollection AddResponseDecorator<TDecorator>(this IServiceCollection services)
			where TDecorator : class, IResponseObjectDecorator
		{
			return services.AddResponseDecorator<TDecorator, TDecorator>();
		}

		public static IServiceCollection AddErrorResponseDecorator(this IServiceCollection services)
		{
			return services.AddResponseDecorator<ErrorsResponseObjectDecorator>();
		}
	}
}
