using AutoMapper;
using Reservation.Application.Commands.CategoryCommand;
using Reservation.Application.Commands.CityCommand;
using Reservation.Application.Commands.CountryCommand;
using Reservation.Application.Repository.Category.Dtos.Responses;
using Reservation.Application.Repository.City.Dtos.Responses;
using Reservation.Application.Repository.Country.Dtos.Responses;

namespace Reservation.Application.Repository.Category
{
    public class CategoryMapper : Profile
    {
        public CategoryMapper()
        {
            //Create
            CreateMap<Core.Entities.Category, CreateCategoryCommand>()
                .ReverseMap();
            CreateMap<Core.Entities.Category, CategoryResponse>()
                .ReverseMap();
        }
    }
}
