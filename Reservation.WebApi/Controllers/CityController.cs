using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reservation.Application.Commands.CityCommand;
using Reservation.Application.Commands.CountryCommand;
using Reservation.Application.Query.CityQuery;
using Reservation.Application.Query.CountryQuery;
using Reservation.Application.Query.TripQuery;

namespace Reservation.WebApi.Controllers
{
    public class CityController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CityController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routers.Router.City.CreateNewCity)]

        public async Task<IActionResult> CreateNewCity([FromBody] CreateCityCommand model)
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
        [HttpPut(Routers.Router.City.UpdateCity)]

        public async Task<IActionResult> UpdateCountry([FromBody] UpdateCityCommand model)
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

        [HttpGet(Routers.Router.City.GetAllCity)]

        public async Task<IActionResult> GetAllCountry([FromQuery] int pageSize, int pageNumber )
        {
            var query = new GetAllCityQuery(pageSize, pageNumber);
            var result = await _mediator.Send(query);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet(Routers.Router.City.GetAllCityDeleted)]

        public async Task<IActionResult> GetAllCountryDeleted([FromQuery] int pageSize , int pageNumber )
        {
            var query = new GetAllCityDeletedQuery(pageSize, pageNumber);
            var result = await _mediator.Send(query);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        [HttpGet(Routers.Router.City.GetCityById)]

        public async Task<IActionResult> GetCityById([FromQuery] Guid id)
        {
            var query = new GetCityDetailsQuery(id);
            var result = await _mediator.Send(query);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpGet(Routers.Router.City.GetAllCountry)]

        public async Task<IActionResult> GetAllCountry()
        {
            var query = new GetAllCountryNameQuery();
            var result = await _mediator.Send(query);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
        [HttpPut(Routers.Router.City.DeleteOrRestoreCity)]
        public async Task<IActionResult> DeleteOrRestoreCity([FromBody] DeleteOrRestoreCityCommand command)
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
