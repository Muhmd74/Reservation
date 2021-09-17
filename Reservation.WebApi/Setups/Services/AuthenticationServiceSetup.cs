using System;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Reservation.Application.Common.Authentication;
using Reservation.WebApi.Setups.Factory.Services;

namespace Reservation.WebApi.Setups.Services
{
    public class AuthenticationServiceSetup : IServiceSetup
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            var jwtTokenConfig = new JwtTokenConfig()
            {
                Secret = "W6zCuNVti8TlA3B7MnDgq7B4NVacovR1",
                Issuer = "SecureApi",
                Audience = "SecureApiUser",
                AccessTokenExpiration = 20,
                RefreshTokenExpiration = 60
            };
            services.AddSingleton(jwtTokenConfig);
            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(x =>
            {
                x.RequireHttpsMetadata = true;
                x.SaveToken = true;
                x.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidIssuer = jwtTokenConfig.Issuer,
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtTokenConfig.Secret)),
                    ValidAudience = jwtTokenConfig.Audience,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.FromMinutes(1)
                };
            });
        }
    }
}
