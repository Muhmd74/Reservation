using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Handler;
using Reservation.Application.Query;

namespace Reservation.WebApi.Controllers
{

    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }


        [HttpGet(Routers.Router.Reservation.GetAllReservation)]

        public async Task<IActionResult> GetAllReservation()
        {
            var query = new GetAllReservationsQuery();
            var result = await _mediator.Send(query);
            return Ok(result);
        }

        [HttpGet(Routers.Router.Reservation.GetReservationById)]

        public async Task<IActionResult> GetReservationById([FromQuery] Guid id)
        {
            var query = new GetReservationByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result != null)
            {
                return Ok(result);
            }

            return NotFound();
        }
    }
}
