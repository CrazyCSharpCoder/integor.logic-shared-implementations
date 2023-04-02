using System;
using System.Collections.Generic;
using System.Net.Sockets;

using Microsoft.Extensions.DependencyInjection;
using Microsoft.AspNetCore.Mvc.ModelBinding;

using Microsoft.EntityFrameworkCore;
using Npgsql;

using IntegorErrorsHandling;
using IntegorErrorsHandling.Converters;
using IntegorErrorsHandling.DefaultImplementations;

using IntegorSharedErrorHandlers;
using IntegorSharedErrorHandlers.Converters;

using IntegorSharedErrorHandlers.ExceptionConverters;
using IntegorSharedErrorHandlers.ExceptionConverters.DataAccess;

namespace IntegorServiceConfiguration
{
	public static class ErrorConvertersServicesExtensions
	{
		/// <summary>
		/// Add IResponseErrorsObjectCompiler and exception converters for string, ModelStateDictionary plus status codes
		/// </summary>
		/// <returns>
		/// Service types of exception converters they can be injected by
		/// </returns>
		public static IEnumerable<Type> AddPrimaryTypesErrorConverters(this IServiceCollection services)
		{
			Dictionary<Type, Type> converterInterfacesToTypes = new Dictionary<Type, Type>()
			{
				{ typeof(IStringErrorConverter), typeof(StandardStringErrorConverter) },
				{ typeof(IResponseErrorsObjectCompiler), typeof(StandardResponseErrorsObjectCompiler) },
				{ typeof(IErrorConverter<ModelStateDictionary>), typeof(ModelStateDictionaryErrorConverter) },

				{ typeof(StatusCodeErrorConverter), typeof(StatusCodeErrorConverter) }
			};

			return services.AddExceptionConverters(converterInterfacesToTypes);
		}

		/// <summary>
		/// Add default implementation for IExceptionErrorConverter<Exception>
		/// </summary>
		/// <returns>
		/// Type "IExceptionErrorConverter<Exception>" that can further be added in controllers exception handling filter
		/// </returns>
		public static Type AddExceptionConverting(this IServiceCollection services)
		{
			services.AddSingleton<IExceptionErrorConverter<Exception>, StandardExceptionErrorConverter>();
			return typeof(IExceptionErrorConverter<Exception>);
		}

		/// <summary>
		/// Add exception converters for database errors
		/// </summary>
		/// <returns>
		/// Service types of exception converters they can be injected by. Use them to specify converter types in controllers exception handling filter
		/// </returns>
		public static IEnumerable<Type> AddDatabaseExceptionConverters(this IServiceCollection services)
		{
			Dictionary<Type, Type> converterInterfacesToTypes = new Dictionary<Type, Type>()
			{
				{ typeof(IExceptionErrorConverter<InvalidOperationException>), typeof(InvalidOperationExceptionConverter) },
				{ typeof(IExceptionErrorConverter<ObjectDisposedException>), typeof(ObjectDisposedExceptionConverter) },
				{ typeof(IExceptionErrorConverter<SocketException>), typeof(SocketExceptionConverter) },

				{ typeof(IExceptionErrorConverter<PostgresException>), typeof(PostgresExceptionConverter) },
				{ typeof(IExceptionErrorConverter<DbUpdateException>), typeof(DbUpdateExceptionConverter) },
			};

			return services.AddExceptionConverters(converterInterfacesToTypes);
		}

		private static IEnumerable<Type> AddExceptionConverters(
			this IServiceCollection services, Dictionary<Type, Type> converterInterfacesToTypes)
		{
			foreach (KeyValuePair<Type, Type> interfaceToType in converterInterfacesToTypes)
				services.AddSingleton(interfaceToType.Key, interfaceToType.Value);

			return converterInterfacesToTypes.Keys;
		}
	}
}
