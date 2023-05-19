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
        public bool IsUserCached => _userCached != null;

        private UserAccountInfoDto? _userCached = null;

        public void CacheUser(UserAccountInfoDto user)
        {
            _userCached = user;
        }

        public UserAccountInfoDto? GetCachedUser()
        {
            return _userCached;
        }
    }
}
