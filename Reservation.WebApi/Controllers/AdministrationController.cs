using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands.AdministrationCommand;
using Reservation.Application.Query.AdministrationQuery;

namespace Reservation.WebApi.Controllers
{
 
    public class AdministrationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdministrationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routers.Router.Administration.CreateRole)]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand model )
        {
            var result = await _mediator.Send(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpGet(Routers.Router.Administration.ListRoles)]
        public async Task<IActionResult> ListRoles()
        {
            var query = new ListRolesQuery();

             var result = await _mediator.Send(query);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPut(Routers.Router.Administration.EditRole)]
        public async Task<IActionResult> EditRole([FromQuery] EditRoleCommand id)
        {
            var result = await _mediator.Send(id);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        //[HttpPut(Routers.Router.Administration.EditUsersInRole)]
        //public async Task<IActionResult> EditUsersInRole([FromBody] List<EditUsersInRoleCommand> id)
        //{
        //    var result = await _mediator.Send(id.ToList());
        //    if (result.Success)
        //    {
        //        return Ok(result);
        //    }
        //    return BadRequest(result);
        //}
    }
}
