using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Http;

using IntegorErrorsHandling;
using IntegorAspHelpers.MicroservicesInteraction;

namespace IntegorSharedAspHelpers.MicroservicesInteraction
{
	public class StandardServiceErrorsToActionResultTranslator : IServiceErrorsToActionResultTranslator
	{
		private IResponseErrorsObjectCompiler _errorsCompiler;

		public StandardServiceErrorsToActionResultTranslator(IResponseErrorsObjectCompiler errorsCompiler)
        {
			_errorsCompiler = errorsCompiler;
        }

        public IActionResult ErrorsToActionResult(IEnumerable<IResponseError> errors)
		{
			object body = _errorsCompiler.CompileResponse(errors.ToArray());

			return new ObjectResult(body)
			{
				StatusCode = StatusCodes.Status500InternalServerError
			};
		}
	}
}
