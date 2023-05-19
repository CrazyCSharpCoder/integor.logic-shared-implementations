using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Authentication;

using IntegorAspHelpers.MicroservicesInteraction.Authorization.RemoteAuthentication;

namespace IntegorServiceConfiguration.Authentication
{
	public static class AuthenticationBuilderExtensions
	{
		public static AuthenticationBuilder AddRemoteAccessRefreshAuthentication(
			this AuthenticationBuilder authenticationBuilder,
			string authenticationScheme = RemoteAccessRefreshAuthenticationDefaults.AuthenticationScheme,
			string? displayName = null,
			Action<RemoteAccessRefreshAuthenticationOptions>? configureOptions = null)
		{
			return authenticationBuilder.AddScheme<
				RemoteAccessRefreshAuthenticationOptions,
				RemoteAccessRefreshAuthenticationHandler>(
				authenticationScheme, displayName, configureOptions);
		}

		public static AuthenticationBuilder AddRemoteAccessRefreshAuthentication(
			this AuthenticationBuilder authenticationBuilder,
			string authenticationScheme = RemoteAccessRefreshAuthenticationDefaults.AuthenticationScheme,
			Action<RemoteAccessRefreshAuthenticationOptions>? configureOptions = null)
		{
			return authenticationBuilder.AddRemoteAccessRefreshAuthentication(authenticationScheme, null, configureOptions);
		}
	}
}
