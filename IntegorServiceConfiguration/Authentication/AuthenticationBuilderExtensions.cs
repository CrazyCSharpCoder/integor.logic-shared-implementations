using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;

using IntegorAspHelpers.MicroservicesInteraction.Authorization.AuthenticationHandlers.Access;

namespace IntegorServiceConfiguration.Authentication
{
	public static class AuthenticationBuilderExtensions
	{
		public static AuthenticationBuilder AddAccessAuthenticationViaMicroservice(
			this AuthenticationBuilder authenticationBuilder,
			string authenticationScheme = ValidateAccessAuthenticationDefaults.AuthenticationScheme,
			string? displayName = null,
			Action<ValidateAccessAuthenticationOptions>? configureOptions = null)
		{
			return authenticationBuilder.AddScheme<ValidateAccessAuthenticationOptions, ValidateAccessAuthenticationHandler>(authenticationScheme, displayName, configureOptions);
		}

		public static AuthenticationBuilder AddAccessAuthenticationViaMicroservice(
			this AuthenticationBuilder authenticationBuilder,
			string authenticationScheme = ValidateAccessAuthenticationDefaults.AuthenticationScheme,
			Action<ValidateAccessAuthenticationOptions>? configureOptions = null)
		{
			return authenticationBuilder.AddAccessAuthenticationViaMicroservice(authenticationScheme, null, configureOptions);
		}

		// TODO implement
		//public static AuthenticationBuilder AddRefreshAuthenticationViaMicroservice(this AuthenticationBuilder authenticationBuilder)
		//{

		//}
	}
}
