using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands;
using Reservation.Application.Commands.ReservationCommand;
using Reservation.Application.Handler;
using Reservation.Application.Query;
using Reservation.Application.Query.ReservationQuery;
using Reservation.Application.Repository.Reservation.Dtos.Request;

namespace Reservation.WebApi.Controllers
{

    public class ReservationController : ControllerBase
    {
        private readonly IMediator _mediator;

        public ReservationController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routers.Router.Reservation.CreateNewReservation)]

        public async Task<IActionResult> CreateNewReservation([FromBody] CreateReservationCommand model)
        {

            var result = await _mediator.Send(model);
            return Ok(result);
        }
        [HttpGet(Routers.Router.Reservation.GetAllReservation)]

        public async Task<IActionResult> GetAllReservation(int pageSize=Int32.MaxValue)
        {
            var query = new GetAllReservationsQuery(pageSize);
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
