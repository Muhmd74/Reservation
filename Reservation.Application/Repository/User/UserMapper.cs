using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Reservation.Application.Repository.TripUser.Dtos.Responses;
using Reservation.Application.Repository.User.Dtos.Responses;

namespace Reservation.Application.Repository.User
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            //GetList
            CreateMap<Core.Entities.User, GetAllUserResponse>().ReverseMap();
           
        }
    }
}
