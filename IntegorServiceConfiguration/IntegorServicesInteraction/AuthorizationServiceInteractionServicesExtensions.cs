using System.Text.Json;

using Microsoft.Extensions.DependencyInjection;

using ExtensibleRefreshJwtAuthentication.Access.Tokens;
using ExtensibleRefreshJwtAuthentication.Refresh.Tokens;

using ExtensibleJwtAuthenticationTokensImplementations.TokensAccess.Access;
using ExtensibleJwtAuthenticationTokensImplementations.TokensAccess.Refresh;

using IntegorPublicDto.Authorization.Users;

using IntegorResponseDecoration.Parsing;
using IntegorSharedResponseDecorators.Authorization.Parsers;

namespace IntegorServiceConfiguration.IntegorServicesInteraction
{
	public static class AuthorizationServiceInteractionServicesExtensions
	{
		public static IServiceCollection AddAuthenticationTokensSending(this IServiceCollection services)
		{
			services.AddSingleton<ISendRequestAccessTokenAccessor, SendRequestAccessTokenCookieAccessor>();
			services.AddSingleton<ISendRequestRefreshTokenAccessor, SendRequestRefreshTokenCookieAccessor>();

			return services;
		}

		public static IServiceCollection AddUserReceiving(this IServiceCollection services)
		{
 			return services.AddSingleton<IDecoratedObjectParser<UserAccountInfoDto, JsonElement>, JsonDecoratedUserParser>();
		}

		// TODO implement for roles

		//public static IServiceCollection AddUserRolesReceiving(this IServiceCollection services)
		//{
			
		//}
	}
}
