using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IntegorErrorsHandling;
using IntegorSharedErrorHandlers.Converters;

using IntegorAspHelpers;

namespace IntegorSharedAspHelpers
{
	public class StandardStatusCodeResponseBodyFactory : IStatusCodeResponseBodyFactory
	{
		private StatusCodeErrorConverter _statusCodeConverter;
		private IResponseErrorsObjectCompiler _errorsCompiler;

		public StandardStatusCodeResponseBodyFactory(
			StatusCodeErrorConverter statusCodeConverter,
			IResponseErrorsObjectCompiler errorsCompiler)
        {
            _statusCodeConverter = statusCodeConverter;
			_errorsCompiler = errorsCompiler;
        }

		public object CreateResponseBody(int statusCode)
		{
			IErrorConvertationResult statusCodeErrors = _statusCodeConverter.Convert(statusCode)!;
			return _errorsCompiler.CompileResponse(statusCodeErrors);
		}
	}
}
