using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Template.CrossCutting.Auth.Interfaces;
using Template.CrossCutting.Auth.Models;
using Template.CrossCutting.Auth.ViewModels;

namespace Template.CrossCutting.Auth.Services
{
    public class TokenService : ITokenService
    {
        private readonly IConfiguration _configuration;
        private readonly IAuthService _serviceAuth;
        private readonly TokenConfigurationsViewModel _tokenConfigurations;

        public TokenService(IConfiguration configuration, IAuthService serviceAuth)
        {
            _configuration = configuration;
            _serviceAuth = serviceAuth;
            _tokenConfigurations = new TokenConfigurationsViewModel();
        }

        public string GenerateToken(ContextUserViewModel user)
        {
            try
            {
                JwtSecurityTokenHandler _tokenHandler = new JwtSecurityTokenHandler();
                byte[] _key = Encoding.ASCII.GetBytes(Settings.Secret);

                SecurityTokenDescriptor _tokenDescriptor = new SecurityTokenDescriptor
                {
                    Subject = _serviceAuth.GetClaimsIdentityByContextUser(user),
                    Expires = DateTime.UtcNow.AddHours(3),
                    NotBefore = DateTime.UtcNow,
                    SigningCredentials = new SigningCredentials(
                        new SymmetricSecurityKey(_key),
                        SecurityAlgorithms.HmacSha256Signature)
                };

                SecurityToken _generatedToken = _tokenHandler.CreateToken(_tokenDescriptor);

                return _tokenHandler.WriteToken(_generatedToken);
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
