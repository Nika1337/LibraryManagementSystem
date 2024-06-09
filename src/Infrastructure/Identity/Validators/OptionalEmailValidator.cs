using Microsoft.AspNetCore.Identity;
using System.Linq;
using System.Threading.Tasks;

namespace Nika1337.Library.Infrastructure.Identity.Validators;

internal class OptionalEmailUserValidator<TUser> : UserValidator<TUser> where TUser : class
{
    public OptionalEmailUserValidator(IdentityErrorDescriber errors) : base(errors)
    {
    }

    public override async Task<IdentityResult> ValidateAsync(UserManager<TUser> manager, TUser user)
    {
        var result = await base.ValidateAsync(manager, user);
        if (!result.Succeeded && string.IsNullOrWhiteSpace(await manager.GetEmailAsync(user)))
        {
            var errors = result.Errors.Where(e => e.Code != "InvalidEmail");
            result = errors.Any() ? IdentityResult.Failed(errors.ToArray()) : IdentityResult.Success;
        }
        return result;
    }
}