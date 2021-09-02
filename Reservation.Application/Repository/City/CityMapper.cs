using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Reservation.Application.Commands.CityCommand;
using Reservation.Application.Repository.City.Dtos.Responses;

namespace Reservation.Application.Repository.City
{
    public class CityMapper : Profile
    {
        public CityMapper()
        {
            //Create
            CreateMap<Core.Entities.City, CreateCityCommand>()
                .ForMember(d => d.CountryId, s => s.MapFrom(a => a.CountryId))
                .ReverseMap();
            CreateMap<Core.Entities.City, CityResponse>()
                .ForMember(d => d.CountryId, s => s.MapFrom(a => a.CountryId))
                .ReverseMap();
            //List
            CreateMap<Core.Entities.City, AllCityResponse>()
                .ForMember(d => d.CountryName, s => s.MapFrom(a => a.Country.Name))
                .ReverseMap();

            CreateMap<Core.Entities.Country, AllCityResponse>()
                .ForMember(d => d.CountryName, s => s.MapFrom(a => a.Name))
                .ForMember(d => d.CountryId, s => s.MapFrom(a => a.Id))

                .ReverseMap();
        }
    }
}
