using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.User.Dtos.Responses;
using Reservation.Core.Enums;

namespace Reservation.Application.Commands.UserCommand
{
    public class CreateUserCommand : IRequest<OutputResponseForValidationFilter>
    {
        [Required]
        public string Name { get; set; }
        [Required]
        public UserType UserType { get; set; }
        [EmailAddress]
        [Required]
        public string Email { get; set; }
        [Required]
         public string Password { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
    }
}
