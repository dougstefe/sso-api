using System.Threading.Tasks;
using IdentityServer4.Models;
using IdentityServer4.Validation;
using Microsoft.AspNetCore.Identity;
using Sso.Domain.Models;
using Sso.Domain.Interfaces.Repositories;

using static IdentityModel.OidcConstants;

namespace Sso.Api.OpenId{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        // private readonly SignInManager<User> _signInManager;
        // private readonly UserManager<User> _userManager;
        private readonly IUserRepository _userRepository;

        public ResourceOwnerPasswordValidator(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            // var signInResult = await _signInManager.PasswordSignInAsync(username, context.Password, false, false);
            var user = await _userRepository.GetUserByUserName(context.UserName.Trim().ToLower());

            // if (signInResult.Succeeded)
            // {
            //     var user = await _userManager.FindByNameAsync(username);
            //     context.Result = new GrantValidationResult(user.Id, AuthenticationMethods.Password, identityProvider: "SsoApi");
            // }
            if (!string.IsNullOrEmpty(user?.UserName) && user.Password.Equals(context.Password))
            {
                context.Result = new GrantValidationResult(user.Id, AuthenticationMethods.Password, identityProvider: "SsoApi");
            }
            else
            {
                context.Result = new GrantValidationResult(TokenRequestErrors.InvalidRequest, errorDescription: "Invalid username or password");
            }
        }
    }
}