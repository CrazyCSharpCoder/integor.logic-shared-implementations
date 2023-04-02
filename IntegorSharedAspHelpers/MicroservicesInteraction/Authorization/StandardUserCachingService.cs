using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using IntegorPublicDto.Authorization.Users;

using IntegorAspHelpers.MicroservicesInteraction.Authorization;

namespace IntegorSharedAspHelpers.MicroservicesInteraction.Authorization
{
	public class StandardUserCachingService : IUserCachingService
	{
		public bool UserCached => throw new NotImplementedException();

		public void CacheUser(UserAccountInfoDto user)
		{
			throw new NotImplementedException();
		}

		public UserAccountInfoDto? GetCachedUser()
		{
			throw new NotImplementedException();
		}
	}
}
