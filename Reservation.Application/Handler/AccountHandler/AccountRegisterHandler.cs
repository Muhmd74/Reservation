using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using Reservation.Application.Commands.AccountCommand;
using Reservation.Application.Common.Authentication;
using Reservation.Application.Common.Response;
using Reservation.Core.Entities;
using JwtRegisteredClaimNames = Microsoft.IdentityModel.JsonWebTokens.JwtRegisteredClaimNames;

namespace Reservation.Application.Handler.AccountHandler
{
    public class AccountRegisterHandler : IRequestHandler<AccountRegisterCommand, AuthResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly SignInManager<ApplicationUser> _signInManager;

        //private readonly JwtAuthManager _authManager;
        private readonly JwtTokenConfig _jwtTokenConfig;

        public AccountRegisterHandler(UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager, JwtTokenConfig jwtTokenConfig)
        {
            _userManager = userManager;
            _signInManager = signInManager;
            _jwtTokenConfig = jwtTokenConfig;
        }

        public async Task<AuthResponse> Handle(AccountRegisterCommand request, CancellationToken cancellationToken)

        {
            if (await _userManager.FindByEmailAsync(request.Email) == null)
            {
                var user = new ApplicationUser()
                {
                    UserName = request.Email,
                    Email = request.Email,
                    FirstName = request.FirstName,
                    LastName = request.LastName
                };
                var result = await _userManager.CreateAsync(user, request.Password);
                 var jwtSecurityToken =await CreateJwtToken(user);
                if (result.Succeeded)
                {
                    await _signInManager.SignInAsync(user, isPersistent: false);
                    try
                    {
                        return new AuthResponse()
                        {
                            Message = ResponseMessages.Success,
                            IsAuthenticated = true,
                            UserName = user.Email,
                            Roles = new List<string>() {"User"},
                            Email = user.Email,
                            ExpiresOn = jwtSecurityToken.ValidTo,
                            Token = new JwtSecurityTokenHandler().WriteToken(jwtSecurityToken)

                        };
                    }
                    catch (Exception e)
                    {
                        var error = string.Empty;
                        foreach (var identityError in result.Errors)
                        {
                            error += $"{identityError.Description}";
                        }
                        return new AuthResponse()
                        {
                            Message = $" Error{error},E message{e.Message}",
                            IsAuthenticated = false,

                        };
                    }

                }

                var errors = string.Empty;
                foreach (var identityError in result.Errors)
                {
                    errors += $"{identityError.Description}";
                }
                return new AuthResponse()
                {
                    Message = errors,
                    IsAuthenticated = false,

                };
            }

            return new AuthResponse()
            {
                Message = "Email is already register",
            };
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
            var symmetricSecurityKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes("W6zCuNVti8TlA3B7MnDgq7B4NVacovR1"));
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
