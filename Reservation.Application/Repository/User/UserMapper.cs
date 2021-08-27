using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Reservation.Application.Commands.UserCommand;
using Reservation.Application.Repository.TripUser.Dtos.Responses;
using Reservation.Application.Repository.User.Dtos.Responses;

namespace Reservation.Application.Repository.User
{
    public class UserMapper : Profile
    {
        public UserMapper()
        {
            CreateMap<Core.Entities.User, GetAllUserResponse>().ReverseMap();
            //Create
            CreateMap<Core.Entities.User, CreateUserCommand>().ReverseMap();
           
        }
    }
}
