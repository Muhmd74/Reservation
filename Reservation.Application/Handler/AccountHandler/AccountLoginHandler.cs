using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Reservation.Application.Commands.AccountCommand;
using Reservation.Application.Common.Authentication;
using Reservation.Application.Common.Response;
using Reservation.Core.Entities;
using Reservation.Core.Interface;

namespace Reservation.Application.Handler.AccountHandler
{
    public class AccountLoginHandler : IRequestHandler<AccountLoginCommand, AuthResponse>
    {
        private readonly UserManager<ApplicationUser> _userManager;

        private readonly IJwtAuthManager _authManager;

        public AccountLoginHandler(UserManager<ApplicationUser> userManager, IJwtAuthManager authManager)
        {
            _userManager = userManager;
            _authManager = authManager;
        }

        public async Task<AuthResponse> Handle(AccountLoginCommand request, CancellationToken cancellationToken)
        {
            var authResponse = new AuthResponse();

            var user = await _userManager.FindByEmailAsync(request.Email);
            var userPassword = await _userManager.CheckPasswordAsync(user, request.Password);

            if (user == null || !userPassword)
            {
                authResponse.Message = "Email or Password is incorrect!";
                return authResponse;
            }
            var jwtSecureModel = await _authManager.CreateJwtToken(user);

            authResponse.IsAuthenticated = true;
            authResponse.Email = user.Email;
            authResponse.ExpiresOn = jwtSecureModel.ValidTo;
            authResponse.Token = new JwtSecurityTokenHandler().WriteToken(jwtSecureModel);
            var rolesList = await _userManager.GetRolesAsync(user);
            authResponse.Roles = rolesList.ToList();

            return authResponse;
        }
    }
}
