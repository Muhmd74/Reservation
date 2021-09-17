using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Reservation.Application.Commands;
using Reservation.Application.Commands.TripUserCommand;
using Reservation.Application.Query;
using Reservation.Application.Query.TripUserQuery;

namespace Reservation.WebApi.Controllers
{
 
    public class TripUserReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TripUserReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        //[Authorize(Roles = "Admin")]

        [HttpPost(Routers.Router.TripUserReservation.Create)]
        public async Task<IActionResult> Create([FromBody] CreateTripUserCommand command)
        {
            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(command);
                if (result.Success)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            return BadRequest(ModelState);

        }
        //[Authorize(Roles = "Admin")]

        [HttpPut(Routers.Router.TripUserReservation.Delete)]
        public async Task<IActionResult> Delete([FromBody] DeleteTripUserCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet(Routers.Router.TripUserReservation.SearchUsers)]
        public async Task<IActionResult> SearchUsers([FromQuery]string name)
        {
            var query=new SearchUserQuery(name);
            var result = await _mediator.Send(query);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
