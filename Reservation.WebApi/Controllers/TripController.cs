﻿using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands;
using Reservation.Application.Commands.TripCommand;
using Reservation.Application.Commands.UserCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Handler;
using Reservation.Application.Query;
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

            var result = await _mediator.Send(model);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPut(Routers.Router.Trip.UpdateTrip)]

        public async Task<IActionResult> UpdateReservation([FromForm] UpdateTripCommand model)
        {

            var result = await _mediator.Send(model);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet(Routers.Router.Trip.GetAllTrip)]

        public async Task<IActionResult> GetAllTrip(int pageSize = Int32.MaxValue)
        {
            var query = new GetAllTripQuery(pageSize);
            var result = await _mediator.Send(query);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet(Routers.Router.Trip.GetAllTripDeleted)]

        public async Task<IActionResult> GetAllTripDeleted(int pageSize = Int32.MaxValue)
        {
            var query = new GetAllTripDeletedQuery(pageSize);
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