using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Reservation.Application.Commands.AccountCommand;
using Reservation.Application.Common.Authentication;
using Reservation.Core.Entities;

namespace Reservation.WebApi.Controllers
{
     public class AccountController : ControllerBase
    {
        private readonly IMediator _mediator;
        public AccountController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routers.Router.Account.Register)]
        public async Task<IActionResult> Register([FromBody] AccountRegisterCommand model)
        {

            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(model);
                if (result.IsAuthenticated)
                {
                    return Ok(result);
                }

                return BadRequest(result);
            }
            return BadRequest(ModelState);
        }


        [HttpPost(Routers.Router.Account.Login)]
        public async Task<IActionResult> Login([FromBody] AccountLoginCommand model)
        {

            if (ModelState.IsValid)
            {
                var result = await _mediator.Send(model);
                if (result.IsAuthenticated)
                {
                    return Ok(new
                    {
                        Token = result.Token,
                        Emial = result.Email,
                        ExpiresOn = result.ExpiresOn
                    });
                }

                return BadRequest(new
                {
                    result.Message
                });
            }
            return BadRequest(ModelState);

        }


    }
}
