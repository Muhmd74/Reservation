using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Reservation.Application.Commands.FirmCommand;
using Reservation.Application.Commands.StaticCommand;
using Reservation.Application.Query.FirmQuery;

namespace Reservation.WebApi.Controllers
{
    public class FirmController : ControllerBase
    {
        private readonly IMediator _mediator;

        public FirmController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routers.Router.Firm.Create)]
        public async Task<IActionResult> Create([FromBody] CreateFirmCommand model)
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

        [HttpPut(Routers.Router.Firm.Update)]
        public async Task<IActionResult> Update([FromBody] UpdateFirmCommand model)
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


        [HttpPut(Routers.Router.Firm.DeleteOrRestore)]
        public async Task<IActionResult> DeleteOrRestore([FromQuery] DeleteOrRestoreCommand model)
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

        [HttpPut(Routers.Router.Firm.ChangeActivity)]
        public async Task<IActionResult> ChangeActivity([FromQuery] ChangeActivityCommand model)
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

        [HttpGet(Routers.Router.Firm.ListFirm)]
        public async Task<IActionResult> ListFirm([FromQuery] int pageSize)
        {
            if (ModelState.IsValid)
            {
                var query = new ListFirmQuery(pageSize);
                var result = await _mediator.Send(query);
                if (result.Success)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }

            return BadRequest(ModelState);

        }

        [HttpGet(Routers.Router.Firm.DetailsFirm)]
        public async Task<IActionResult> DetailsFirm([FromQuery] Guid id)
        {
            if (ModelState.IsValid)
            {
                var query = new DetailsFirmQuery(id);
                var result = await _mediator.Send(query);
                if (result.Success)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }

            return BadRequest(ModelState);

        }
    }
}
