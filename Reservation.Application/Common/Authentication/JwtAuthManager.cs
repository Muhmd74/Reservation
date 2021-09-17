using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Reservation.Application.Commands.AccountCommand;
using Reservation.Application.Common.Response;
using Reservation.Core.Entities;
using Reservation.Core.Interface;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Reservation.Application.Common.Authentication
{

    public class JwtAuthManager : IJwtAuthManager
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly JwtTokenConfig _jwtTokenConfig;

        public JwtAuthManager(UserManager<ApplicationUser> userManager, JwtTokenConfig jwtTokenConfig)
        {
            _userManager = userManager;
            _jwtTokenConfig = jwtTokenConfig;
        }

        public async Task<JwtSecurityToken> CreateJwtToken(ApplicationUser user)
        {
            var userClaims = await _userManager.GetClaimsAsync(user);
            var roles = await _userManager.GetRolesAsync(user);
            var rolesClaims = new List<Claim>();

            foreach (var role in roles)
            {
                rolesClaims.Add(new Claim("roles", role));
            }

            var claims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                    new Claim(JwtRegisteredClaimNames.Email, user.Email),
                    new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
                    new Claim("uid", user.Id),
                }
                .Union(userClaims)
                .Union(rolesClaims);
            var symmetricSecurityKey =
                new SymmetricSecurityKey(Encoding.ASCII.GetBytes("W6zCuNVti8TlA3B7MnDgq7B4NVacovR1"));
            var signingCredentials = new SigningCredentials(symmetricSecurityKey, SecurityAlgorithms.HmacSha256);
            var jwtSecurityToken = new JwtSecurityToken(

                issuer: _jwtTokenConfig.Issuer,
                audience: _jwtTokenConfig.Audience,
                claims: claims,
                expires: DateTime.Now.AddDays(_jwtTokenConfig.AccessTokenExpiration),
                signingCredentials: signingCredentials);

            return jwtSecurityToken;
        }

    }
}
