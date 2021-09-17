using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MediatR;
 using Reservation.Application.Common.Response;
namespace Reservation.Application.Commands.AccountCommand
{
    public class AccountRegisterCommand : IRequest<AuthResponse>
    {
        [Required]
        [EmailAddress]
         public string Email { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Password { get; set; }

        [DataType(DataType.Password)]
         [Compare("Password",
            ErrorMessage = "Password and confirmation password do not match.")]
        public string ConfirmPassword { get; set; }
         public string FirstName { get; set; }
         public string LastName { get; set; }
    }
}
