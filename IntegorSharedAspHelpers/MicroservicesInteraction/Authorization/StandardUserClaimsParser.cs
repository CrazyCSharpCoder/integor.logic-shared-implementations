using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Claims;

using ExtensibleRefreshJwtAuthentication;

using IntegorPublicDto.Authorization.Users;
using IntegorLogicShared.Types.Authorization;

using IntegorLogicShared.MicroserviceSpecific.Authorization;
using IntegorAspHelpers.MicroservicesInteraction.Authorization;

namespace IntegorSharedAspHelpers.MicroservicesInteraction.Authorization
{
	public class StandardUserClaimsParser : IUserClaimsParser
	{
		private const string _userIdClaim = "UserId";
		private readonly string _usernameClaim;
		private readonly string _userRoleClaim;

		private UserRolesConverter _rolesConverter;

		public StandardUserClaimsParser(IClaimTypesNamer claimTypes, UserRolesConverter rolesConverter)
        {
			_rolesConverter = rolesConverter;

			_usernameClaim = claimTypes.UsernameClaimType;
			_userRoleClaim = claimTypes.UserRoleClaimType;
        }

        public UserClaimNames GetClaimNames()
			=> new UserClaimNames(_userIdClaim, _usernameClaim, _userRoleClaim);

		public int GetId(IEnumerable<Claim> claims)
		{
			string strId = GetClaimByType(claims, _userIdClaim).Value;
			return Int32.Parse(strId);
		}

		public string GetUserame(IEnumerable<Claim> claims)
			=> GetClaimByType(claims, _usernameClaim).Value;

		public UserRoles GetUserRole(IEnumerable<Claim> claims)
		{
			string strRole = GetClaimByType(claims, _userRoleClaim).Value;
			int roleId = Int32.Parse(strRole);

			return _rolesConverter.RoleIdToRolesEnum(roleId);
		}

		public Claim[] UserToClaims(UserAccountInfoDto user)
		{
			return new Claim[]
			{
				new Claim(_userIdClaim, user.Id.ToString()),
				new Claim(_usernameClaim, user.EMail.ToString()),
				new Claim(_userRoleClaim, user.Role.Id.ToString())
			};
		}

		private Claim GetClaimByType(IEnumerable<Claim> claims, string claimType)
		{
			return claims.First(claim => claim.Type == claimType);
		}
	}
}
