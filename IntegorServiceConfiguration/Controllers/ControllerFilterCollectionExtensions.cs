using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

using IntegorErrorsHandling.Filters;
using IntegorSharedResponseDecorators.Shared.Attributes;

using IntegorAspHelpers.MicroservicesInteraction.Filters;

namespace IntegorServiceConfiguration.Controllers
{
	public static class ControllerFilterCollectionExtensions
	{
		public static void AddErrorsDecoration(this FilterCollection filters)
		{
			filters.Add(new DecorateErrorsResponseAttribute());
		}

		public static void AddErrorsHandling(this FilterCollection filters, params Type[] exceptionConverters)
		{
			filters.Add(new ExtensibleExeptionHandlingLazyFilterFactory(exceptionConverters));
		}

		/// <summary>
		/// Add DecorateErrorsResponseAttribute, ExtensibleExceptionHandlingLazyFilterFactory, ServiceFilterAttribute
		/// </summary>
		/// <param name="exceptionConverters">
		/// Exception converters to be applied to ExtensibleExceptionHandlingLazyFilterFactory
		/// </param>
		public static void AddDefaultFilters(this FilterCollection filters, params Type[] exceptionConverters)
		{
			filters.AddErrorsDecoration();
			filters.AddErrorsHandling(exceptionConverters);
		}

		public static void AddServiceErrorsToActionResult(this FilterCollection filters)
		{
			filters.Add(new ApplicationServiceErrorsTranslationFilterAttribute());
		}
	}
}
