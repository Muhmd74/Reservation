﻿using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands;
using Reservation.Application.Commands.UserCommand;
using Reservation.Application.Query;
using Reservation.Application.Query.UserQuery;

namespace Reservation.WebApi.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet(Routers.Router.User.GetAllUser)]
        public async Task<IActionResult> GetAllUser(int pageSize=Int32.MaxValue)
        {
            var query = new GetAllUserQuery(pageSize);
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpPut(Routers.Router.User.ChangeActivity)]
        public async Task<IActionResult> ChangeActivity([FromBody] ChangeActivityCommand model )
        {
             var result = await _mediator.Send(model);
            return Ok(result);
        }
    }
}
