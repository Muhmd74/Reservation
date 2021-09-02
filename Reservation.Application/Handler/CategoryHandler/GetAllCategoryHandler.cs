using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Query.CategoryQuery;
using Reservation.Application.Repository.Category;
using Reservation.Application.Repository.Category.Dtos.Responses;

namespace Reservation.Application.Handler.CategoryHandler
{
    public class GetAllCategoryHandler : IRequestHandler<GetAllCategoryQuery,OutputResponse<List<CategoryResponse>>>
    {
        private readonly ICategory _category;

        public GetAllCategoryHandler(ICategory category)
        {
            _category = category;
        }

        public async Task<OutputResponse<List<CategoryResponse>>> Handle(GetAllCategoryQuery request, CancellationToken cancellationToken)
        {
            var result =await _category.GetAllCategory(request.PageSize);
            return result;
        }
    }
}
