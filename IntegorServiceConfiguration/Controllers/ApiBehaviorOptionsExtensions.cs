using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.Extensions.DependencyInjection;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using IntegorErrorsHandling;
using IntegorErrorsHandling.Converters;

namespace IntegorServiceConfiguration.Controllers
{
	public static class ApiBehaviorOptionsExtensions
	{
		public static void SetDefaultInvalidModelStateResponseFactory(this ApiBehaviorOptions options)
		{
			options.InvalidModelStateResponseFactory = OnInvalidModelStateResponse;
		}

		private static IActionResult OnInvalidModelStateResponse(ActionContext context)
		{
			IServiceProvider services = context.HttpContext.RequestServices;

			IErrorConverter<ModelStateDictionary> converter =
				services.GetRequiredService<IErrorConverter<ModelStateDictionary>>();

			IResponseErrorsObjectCompiler errorsCompiler =
				services.GetRequiredService<IResponseErrorsObjectCompiler>();

			IErrorConvertationResult convertResult = converter.Convert(context.ModelState)!;
			object errorBody = errorsCompiler.CompileResponse(convertResult);

			return new BadRequestObjectResult(errorBody);
		}
	}
}
