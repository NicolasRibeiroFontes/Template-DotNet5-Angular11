using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Template.CrossCutting.Auth.Interfaces;
using Template.CrossCutting.Auth.ViewModels;
using Template.CrossCutting.ExceptionHandler.Extensions;

namespace Template.CrossCutting.Auth.Services
{
    public class AuthService : IAuthService
    {
        private readonly IHttpContextAccessor _httpContextAccessor;

        public AuthService(IHttpContextAccessor httpContextAccessor)
        {
            _httpContextAccessor = httpContextAccessor;
        }

        public string GetWindowsUser()
        {
            if (_httpContextAccessor?.HttpContext?.User == null)
                return null;

            return _httpContextAccessor?.HttpContext?.User.Identity.Name;
        }

        public ContextUserViewModel GetLoggedUser()
        {
            try
            {
                if (_httpContextAccessor?.HttpContext?.User == null)
                    return null;

                return new ContextUserViewModel
                {
                    Id = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.PrimarySid).Value,
                    Email = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.NameIdentifier).Value,
                    Name = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Name).Value,
                    Profile = _httpContextAccessor.HttpContext.User.FindFirst(ClaimTypes.Role).Value,
                    IsAuthenticated = _httpContextAccessor.HttpContext.User.Identity.IsAuthenticated,
                };
            }
            catch (Exception)
            {
                throw new ApiException("Invalid Token", HttpStatusCode.Unauthorized);
            }
        }

        public ClaimsIdentity GetClaimsIdentityByContextUser(ContextUserViewModel user, string authenticationType = "Bearer")
        {
            try
            {
                return new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.PrimarySid, user.Id),
                    new Claim(ClaimTypes.NameIdentifier, user.Email),
                    new Claim(ClaimTypes.Name, user.Name),
                    new Claim(ClaimTypes.Role, user.Profile)
                }, authenticationType);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
