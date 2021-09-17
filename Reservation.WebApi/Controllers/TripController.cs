using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands.TripCommand;
using Reservation.Application.Query.TripQuery;

namespace Reservation.WebApi.Controllers
{

    public class TripController : ControllerBase
    {
        private readonly IMediator _mediator;

        public TripController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routers.Router.Trip.CreateNewTrip)]

        public async Task<IActionResult> CreateNewTrip([FromForm] CreateTripCommand model)
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
        [HttpPut(Routers.Router.Trip.UpdateTrip)]

        public async Task<IActionResult> UpdateReservation([FromForm] UpdateTripCommand model)
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

        [HttpGet(Routers.Router.Trip.GetAllTrip)]

        public async Task<IActionResult> GetAllTrip([FromQuery]int pageSize = Int32.MaxValue,int pageNumber=Int32.MaxValue)
        {
            var query = new GetAllTripQuery(pageSize,pageNumber);
            var result = await _mediator.Send(query);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet(Routers.Router.Trip.GetAllTripDeleted)]

        public async Task<IActionResult> GetAllTripDeleted([FromQuery]int pageSize = Int32.MaxValue, int pageNumber = Int32.MaxValue)
        {
            var query = new GetAllTripDeletedQuery(pageSize,pageNumber);
            var result = await _mediator.Send(query);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet(Routers.Router.Trip.GetTripById)]

        public async Task<IActionResult> GetTripById([FromQuery] Guid id)
        {
            var query = new GetTripByIdQuery(id);
            var result = await _mediator.Send(query);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpPut(Routers.Router.Trip.DeleteOrRestoreTrip)]
        public async Task<IActionResult> DeleteOrRestoreTrip([FromBody] DeleteOrRestoreTripCommand command)
        {
            var result = await _mediator.Send(command);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
