using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.User.Dtos.Responses;
using Reservation.Core.Enums;

namespace Reservation.Application.Commands.UserCommand
{
    public class CreateUserCommand :IRequest<OutputResponse<GetAllUserResponse>>
    {
         public string Name { get; set; }
        public UserType UserType { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
