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

        private readonly IJwtAuthManager _authManager;

        public AccountRegisterHandler(  UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager, IJwtAuthManager authManager)
        {
             _userManager = userManager;
            _signInManager = signInManager;
            _authManager = authManager;
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
                 var jwtSecurityToken =await _authManager.CreateJwtToken(user);
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

    }
}
