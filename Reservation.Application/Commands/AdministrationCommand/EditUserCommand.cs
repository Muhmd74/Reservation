using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;

namespace Reservation.Application.Commands.AdministrationCommand
{
    public class EditUserCommand : IRequest<OutputResponseForValidationFilter>
    {
        public EditUserCommand()
        {
            Roles = new List<string>();
        }

        public string Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

         public string FirstName { get; set; }
        public string LastName { get; set; }

        public IList<string> Roles { get; set; }
        public string PhoneNumber { get; set; }
    }
}
