using System;
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
		public static IServiceCollection AddPrimaryTypesErrorConverters(this IServiceCollection services)
		{
			services.AddSingleton<IStringErrorConverter, StandardStringErrorConverter>();
			services.AddSingleton<IResponseErrorsObjectCompiler, StandardResponseErrorsObjectCompiler>();
			services.AddSingleton<IErrorConverter<ModelStateDictionary>, ModelStateDictionaryErrorConverter>();

			services.AddSingleton<StatusCodeErrorConverter>();

			return services;
		}

		public static IServiceCollection AddExceptionConverting(this IServiceCollection services)
		{
			return services.AddSingleton<IExceptionErrorConverter<Exception>, StandardExceptionErrorConverter>();
		}

		public static IServiceCollection AddDatabaseExceptionConverters(this IServiceCollection services)
		{
			services.AddSingleton<IExceptionErrorConverter<InvalidOperationException>, InvalidOperationExceptionConverter>();
			services.AddSingleton<IExceptionErrorConverter<ObjectDisposedException>, ObjectDisposedExceptionConverter>();
			services.AddSingleton<IExceptionErrorConverter<SocketException>, SocketExceptionConverter>();

			services.AddSingleton<IExceptionErrorConverter<PostgresException>, PostgresExceptionConverter>();
			services.AddSingleton<IExceptionErrorConverter<DbUpdateException>, DbUpdateExceptionConverter>();

			return services;
		}
	}
}
