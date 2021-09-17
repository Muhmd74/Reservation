using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;

namespace Reservation.Application.Commands.AdministrationCommand
{
    public class ManageUserRolesCommand : IRequest<OutputResponseForValidationFilter>
    {

        public string RoleId { get; set; }
        public string RoleName { get; set; }
        public bool IsSelected { get; set; }
        public string UserId { get; set; }

        public List<ManageUserRolesCommand> ListManageUserRolesCommand()
        {
            return new List<ManageUserRolesCommand>();
        }
    }
}
