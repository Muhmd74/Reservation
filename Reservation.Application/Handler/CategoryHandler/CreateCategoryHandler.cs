using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Commands.CategoryCommand;
using Reservation.Application.Commands.CityCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Category;
using Reservation.Application.Repository.Category.Dtos.Responses;
using Reservation.Application.Repository.City;
using Reservation.Application.Repository.City.Dtos.Responses;

namespace Reservation.Application.Handler.CategoryHandler
{
    public class CreateCategoryHandler : IRequestHandler<CreateCategoryCommand, OutputResponse<CategoryResponse>>
    {
        private readonly ICategory _category;

        public CreateCategoryHandler(ICategory category)
        {
            _category = category;
        }

        public async Task<OutputResponse<CategoryResponse>> Handle(CreateCategoryCommand request, CancellationToken cancellationToken)
        {
            var result = await _category.CreateCategory(request);
            return result;
        }
    }
}
