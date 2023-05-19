using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

namespace IntegorServiceConfiguration.Controllers
{
	public static class ControllersConfigurationExtensions
	{
		public static IMvcBuilder AddDefaultControllersConfiguration(
			this IServiceCollection services, params Type[] exceptionConverters)
		{
			return services.AddControllers(options =>
			{
				options.Filters.AddErrorsDecoration();
				options.Filters.AddErrorsHandling(exceptionConverters);
			})
			.ConfigureApiBehaviorOptions(options =>
			{
				options.SetDefaultInvalidModelStateResponseFactory();
			});
		}
	}
}
