using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Reservation.Application.Commands.CountryCommand;
using Reservation.Application.Commands.UserCommand;
using Reservation.Application.Repository.Country.Dtos.Responses;
using Reservation.Application.Repository.User.Dtos.Responses;

namespace Reservation.Application.Repository.Country
{
    public class CountryMapper : Profile
    {
        public CountryMapper()
        {
            //Create
            CreateMap<Core.Entities.Country, CreateCountryCommand>().ReverseMap();
            CreateMap<Core.Entities.Country, CountryResponse>().ReverseMap();

        }
    }
}
