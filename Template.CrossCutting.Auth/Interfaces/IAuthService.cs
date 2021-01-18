using System.Security.Claims;
using Template.CrossCutting.Auth.ViewModels;

namespace Template.CrossCutting.Auth.Interfaces
{
    public interface IAuthService
    {
        ContextUserViewModel GetLoggedUser();
        ClaimsIdentity GetClaimsIdentityByContextUser(ContextUserViewModel user, string authenticationType = "Bearer");
    }
}
