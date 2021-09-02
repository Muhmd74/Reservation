using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Reservation.Application.Commands.CategoryCommand;
using Reservation.Application.Commands.CityCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Category.Dtos.Responses;
using Reservation.Application.Repository.City.Dtos.Responses;

namespace Reservation.Application.Repository.Category
{
    public interface ICategory
    {
        Task<OutputResponse<CategoryResponse>> CreateCategory(CreateCategoryCommand model);
        Task<OutputResponse<List<CategoryResponse>>> GetAllCategory(int pageSize = Int32.MaxValue);
        Task<OutputResponse<List<CategoryResponse>>> GetAllCategoryDeleted(int pageSize = Int32.MaxValue, int pageNumber = Int32.MaxValue);

        Task<OutputResponse<CategoryResponse>> GetByCategoryId(Guid id);
        Task<OutputResponse<CategoryResponse>> UpdateCategory(UpdateCategoryCommand model);
        Task<OutputResponse<bool>> DeleteOrRestore(Guid id);
    }
}
