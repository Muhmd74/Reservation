using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands.CountryCommand;
using Reservation.Application.Commands.TripCommand;
using Reservation.Application.Query.CountryQuery;
using Reservation.Application.Query.TripQuery;

namespace Reservation.WebApi.Controllers
{

    public class CountryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CountryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routers.Router.Country.CreateNewCountry)]

        public async Task<IActionResult> CreateNewCountry([FromBody] CreateCountryCommand model)
        {

            var result = await _mediator.Send(model);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPut(Routers.Router.Country.UpdateCountry)]

        public async Task<IActionResult> UpdateCountry([FromBody] UpdateCountryCommand model)
        {

            var result = await _mediator.Send(model);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet(Routers.Router.Country.GetAllCountry)]

        public async Task<IActionResult> GetAllCountry([FromQuery] int pageSize = Int32.MaxValue, int pageNumber = Int32.MaxValue)
        {
            var query = new GetAllCountryQuery(pageSize, pageNumber);
            var result = await _mediator.Send(query);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet(Routers.Router.Country.GetAllCountryDeleted)]

        public async Task<IActionResult> GetAllCountryDeleted([FromQuery] int pageSize = Int32.MaxValue, int pageNumber = Int32.MaxValue)
        {
            var query = new GetAllCountryDeletedQuery(pageSize, pageNumber);
            var result = await _mediator.Send(query);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet(Routers.Router.Country.GetCountryById)]

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

        [HttpPut(Routers.Router.Country.DeleteOrRestoreCountry)]
        public async Task<IActionResult> DeleteOrRestoreCountry([FromBody] DeleteOrRestoreCountryCommand command)
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

