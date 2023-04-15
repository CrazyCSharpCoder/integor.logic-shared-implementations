using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

using Microsoft.Extensions.Options;

using ExtensibleRefreshJwtAuthentication;

using IntegorPublicDto.Authorization.Users;
using IntegorLogicShared.Types.IntegorServices.Authorization;

using IntegorLogicShared.IntegorServices.Authorization;
using IntegorAspHelpers.MicroservicesInteraction.Authorization;

namespace IntegorSharedAspHelpers.MicroservicesInteraction.Authorization
{
	public class StandardUserClaimsParser : IUserClaimsParser
	{
		private ExtendedClaimTypesNames _claimTypes;
		private UserRolesEnumConverter _rolesConverter;

		public StandardUserClaimsParser(
			IOptions<ExtendedClaimTypesNames> claimTypesOptions,
			UserRolesEnumConverter rolesConverter)
		{
			_claimTypes = claimTypesOptions.Value;
			_rolesConverter = rolesConverter;
        }

		public Claim[] UserToClaims(UserAccountInfoDto user)
		{
			return new Claim[]
			{
				new Claim(_claimTypes.UserIdClaimType, user.Id.ToString()),
				new Claim(_claimTypes.UsernameClaimType, user.EMail.ToString()),
				new Claim(_claimTypes.UserRoleClaimType, user.Role.Id.ToString())
			};
		}

		public int ParseId(string idClaimValue)
		{
			return Int32.Parse(idClaimValue);
		}

		public string ParseUsername(string usernameClaimValue)
		{
			return usernameClaimValue;
		}

		public UserRoles ParseUserRole(string userRoleClaimValue)
		{
			int roleId = Int32.Parse(userRoleClaimValue);
			return _rolesConverter.RoleIdToRolesEnum(roleId);
		}
	}
}
