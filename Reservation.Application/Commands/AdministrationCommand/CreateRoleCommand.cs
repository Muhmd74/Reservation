using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;

namespace Reservation.Application.Commands.AdministrationCommand
{
    public class CreateRoleCommand : IRequest<OutputResponseForValidationFilter>
    {
        [Required]
        public string RoleName { get; set; }
    }
}
