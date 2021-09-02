using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Reservation.Application.Commands.CategoryCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Category.Dtos.Responses;
using Reservation.Application.Repository.City;
using Reservation.Application.Repository.City.Dtos.Responses;
using Reservation.Infrastructure.Data.ApplicationDbContext;

namespace Reservation.Application.Repository.Category
{
    public class CategoryService : ICategory
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapperManager;


        public CategoryService(IMapper mapperManager, ApplicationDbContext context)
        {
            _mapperManager = mapperManager;
            _context = context;
        }

        public async Task<OutputResponse<CategoryResponse>> CreateCategory(CreateCategoryCommand model)
        {
            try
            {

                var category = _mapperManager.Map<Core.Entities.Category>(model);
                var result = await _context.Categories.AddAsync(category);
                await _context.SaveChangesAsync();
                return new OutputResponse<CategoryResponse>()
                {
                    Model = _mapperManager.Map<CategoryResponse>(result.Entity),
                    Message = ResponseMessages.Success,
                    Success = true
                };
            }
            catch (Exception e)
            {
                return new OutputResponse<CategoryResponse>()
                {
                    Model = null,
                    Message = e.Message,
                    Success = true,
                    Errors = new List<ErrorModel> {
                        new ErrorModel {
                            Message = e.Message,
                            Property = "Exception"
                        },
                        new ErrorModel {
                            Message = e.InnerException?.Message,
                            Property = "Inner Exception"
                        },
                        new ErrorModel {
                            Message = e.Source,
                            Property = "Source"
                        }
                    }
                };
            }
        }

        public async Task<OutputResponse<List<CategoryResponse>>> GetAllCategory(int pageSize = Int32.MaxValue)
        {

            var model = await _context.Categories

                .Where(d => d.IsDeleted == false)
                 .Take(pageSize)
                .ToListAsync();

            return new OutputResponse<List<CategoryResponse>>()
            {
                Model = _mapperManager.Map<List<CategoryResponse>>(model),
                Message = ResponseMessages.Success,
                Success = true
            };
        }

        public async Task<OutputResponse<List<CategoryResponse>>> GetAllCategoryDeleted(int pageSize = Int32.MaxValue, int pageNumber = Int32.MaxValue)
        {
            var start = pageNumber * pageSize - pageSize;

            var model = await _context.Categories

                .Where(d => d.IsDeleted)
                .Skip(start).Take(pageSize)
                .ToListAsync();

            return new OutputResponse<List<CategoryResponse>>()
            {
                Model = _mapperManager.Map<List<CategoryResponse>>(model),
                Message = ResponseMessages.Success,
                Success = true
            };
        }

        public async Task<OutputResponse<CategoryResponse>> GetByCategoryId(Guid id)
        {
            var model = await _context.Categories.FirstOrDefaultAsync(d => d.Id == id);
            if (model != null)
            {
                return new OutputResponse<CategoryResponse>()
                {
                    Model = _mapperManager.Map<CategoryResponse>(model),
                    Message = ResponseMessages.Success,
                    Success = true
                };
            }
            return new OutputResponse<CategoryResponse>()
            {
                Model = null,
                Message = ResponseMessages.NotFound,
                Success = false
            };
        }

        public async Task<OutputResponse<CategoryResponse>> UpdateCategory(UpdateCategoryCommand model)
        {
            var country = await _context.Categories.FirstOrDefaultAsync(d => d.Id == model.Id);

            if (country != null)
            {
                UpdateMapper(model, country);
                await _context.SaveChangesAsync();
                return new OutputResponse<CategoryResponse>()
                {
                    Model = _mapperManager.Map<CategoryResponse>(country),
                    Message = ResponseMessages.Success,
                    Success = true
                };
            }
            return new OutputResponse<CategoryResponse>()
            {
                Model = null,
                Message = ResponseMessages.NotFound,
                Success = false
            };
        }
        public void UpdateMapper(UpdateCategoryCommand target, Core.Entities.Category source)
        {

            source.Name = target.Name;
            source.Description = target.Description;


        }
        public Task<OutputResponse<bool>> DeleteOrRestore(Guid id)
        {
            throw new NotImplementedException();
        }
    }
}
