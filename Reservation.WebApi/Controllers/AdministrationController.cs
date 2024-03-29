﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Reservation.Application.Commands.AdministrationCommand;
using Reservation.Application.Query.AdministrationQuery;

namespace Reservation.WebApi.Controllers
{
    //[Authorize(Roles = "Admin")]

    public class AdministrationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public AdministrationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routers.Router.Administration.CreateRole)]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleCommand model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(model);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }

            return BadRequest(ModelState);
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
        public async Task<IActionResult> EditRole([FromBody] EditRoleCommand model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(model);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }
            return BadRequest(ModelState);

        }
        [HttpPut(Routers.Router.Administration.EditUser)]
        public async Task<IActionResult> EditUser([FromBody] EditRoleCommand model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(model);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }
            return BadRequest(ModelState);

        }

        [HttpGet(Routers.Router.Administration.ListUsers)]
        public async Task<IActionResult> ListUsers([FromQuery] int pageSize)
        {
            var query = new ListUsersQuery(pageSize);

            var result = await _mediator.Send(query);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }
        [HttpPost(Routers.Router.Administration.DeleteUser)]
        public async Task<IActionResult> DeleteUser([FromQuery] DeleteUserCommand model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(model);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);
            }
            return BadRequest(ModelState);

        }

        [HttpPost(Routers.Router.Administration.DeleteRole)]
        public async Task<IActionResult> DeleteRole([FromQuery] DeleteRoleCommand model)
        {
            var result = await _mediator.Send(model);
            if (result.Success)
            {
                return Ok(result);
            }
            return BadRequest(result);
        }

        [HttpPost(Routers.Router.Administration.ManageUserRoles)]
        public async Task<IActionResult> ManageUserRoles([FromBody] ManageUserRolesCommand model)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(model);
                if (result.Success)
                {
                    return Ok(result);
                }
                return BadRequest(result);

            }
            return BadRequest(ModelState);

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
