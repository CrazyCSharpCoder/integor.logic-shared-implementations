using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

using IntegorAspHelpers.MicroservicesInteraction.Authorization.Claims;

namespace IntegorSharedAspHelpers.MicroservicesInteraction.Authorization.Claims
{
    public class StandardClaimsValidator : IClaimsValidator
    {
		public bool ValidateId(int id)
        {
            return id >= 1;
        }

        public bool ValidateUsername(string username)
        {
            EmailAddressAttribute emailValidator = new EmailAddressAttribute();
            return emailValidator.IsValid(username);
        }
    }
}
