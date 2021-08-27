using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
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

        [HttpPost(Routers.Router.TripUserReservation.Create)]
        public async Task<IActionResult> Create([FromBody] CreateTripUserCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut(Routers.Router.TripUserReservation.Delete)]
        public async Task<IActionResult> Create([FromBody] DeleteTripUserCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet(Routers.Router.TripUserReservation.SearchUsers)]
        public async Task<IActionResult> Create([FromQuery]string name)
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
