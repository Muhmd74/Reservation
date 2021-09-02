using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Category.Dtos.Responses;

namespace Reservation.Application.Query.CategoryQuery
{
    public class GetAllCategoryQuery :  IRequest<OutputResponse<List<CategoryResponse>>>
    {
        public GetAllCategoryQuery(int pageSize)
        {
            PageSize = pageSize;
        }

        public int PageSize { get; }
    }
}
