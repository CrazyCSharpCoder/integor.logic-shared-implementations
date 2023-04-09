using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc;

using IntegorAspHelpers.Http.Filters;

namespace IntegorServiceConfiguration.Controllers
{
	public static class ControllersConfigurationExtensions
	{
		public static IMvcBuilder AddControllersWithProcessedMarking(
			this IServiceCollection services, Action<MvcOptions> configure)
		{
			services.AddScoped<SetProcessedFilter>();
			return services.AddControllers(configure);
		}

		public static IMvcBuilder AddDefaultControllersConfiguration(
			this IServiceCollection services, params Type[] exceptionConverters)
		{
			services.AddScoped<SetProcessedFilter>();

			return services.AddControllers(options =>
			{
				options.Filters.AddErrorsDecoration();
				options.Filters.AddErrorsHandling(exceptionConverters);
				options.Filters.AddSetProcessedByDefault();
			})
			.ConfigureApiBehaviorOptions(options =>
			{
				options.SetDefaultInvalidModelStateResponseFactory();
			});
		}
	}
}
