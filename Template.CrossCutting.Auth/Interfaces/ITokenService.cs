using Template.CrossCutting.Auth.ViewModels;

namespace Template.CrossCutting.Auth.Interfaces
{
    public interface ITokenService
    {
        string GenerateToken(ContextUserViewModel usuario);
    }
}
