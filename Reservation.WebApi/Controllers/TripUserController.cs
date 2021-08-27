using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands;

namespace Reservation.WebApi.Controllers
{
 
    public class TripUserController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TripUserController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routers.Router.TripUser.Create)]
        public async Task<IActionResult> Create([FromBody] CreateTripUserCommand command)
        {
            var result = await _mediator.Send(command);
            return Ok(result);
        }
    }
}
