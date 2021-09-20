using System;
 
using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using Reservation.Application.Commands.CategoryCommand;
 using Reservation.Application.Query.CategoryQuery;
 
namespace Reservation.WebApi.Controllers
{

    public class CategoryController : ControllerBase
    {
        private readonly IMediator _mediator;

        public CategoryController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost(Routers.Router.Category.CreateNewCategory)]

        public async Task<IActionResult> CreateNewCategory([FromBody] CreateCategoryCommand model)
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

        [HttpGet(Routers.Router.Category.GetAllCategory)]

        public async Task<IActionResult> GetAllCategory(int pageSize=Int32.MaxValue)
        {
            var query = new GetAllCategoryQuery(pageSize);

            var result = await _mediator.Send(query);
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }
    }
}
