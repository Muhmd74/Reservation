using System;
using System.Collections.Generic;
using System.Text;
using MediatR;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Category.Dtos.Responses;

namespace Reservation.Application.Commands.CategoryCommand
{
    public class CreateCategoryCommand : IRequest<OutputResponse<CategoryResponse>>
    {
        public string Name { get; set; }
        public string Description { get; set; }
    }
}
