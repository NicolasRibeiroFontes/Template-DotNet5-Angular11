using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Text;
using Template.CrossCutting.Auth.Models;

namespace Template.CrossCutting.Auth.Providers
{
    public static class JWTConfiguration
    {
        public static IServiceCollection AddCustomJWTConfiguration(this IServiceCollection services)
        {
            try
            {
                byte[] _key = Encoding.ASCII.GetBytes(Settings.Secret);

                services.AddAuthentication(x =>
                {
                    x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                    x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
                })
                    .AddJwtBearer(x =>
                    {
                        x.RequireHttpsMetadata = false;
                        x.SaveToken = true;
                        x.TokenValidationParameters = new TokenValidationParameters
                        {
                            ValidateIssuerSigningKey = true,
                            IssuerSigningKey = new SymmetricSecurityKey(_key),
                            ValidateIssuer = false,
                            ValidateAudience = false,
                            RequireExpirationTime = true
                        };
                    });

                return services;
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
