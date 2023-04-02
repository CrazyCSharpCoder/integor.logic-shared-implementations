using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using ExtensibleRefreshJwtAuthentication;

namespace ExtensibleJwtAuthenticationTokensImplementations
{
	public class StandardClaimTypesNamer : IClaimTypesNamer
	{
		private const string _username = "Username";
		private const string _userId = "UserId";

		public string UsernameClaimType => _username;
		public string UserRoleClaimType => _userId;
	}
}
