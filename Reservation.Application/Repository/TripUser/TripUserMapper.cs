using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Reservation.Application.Commands;
using Reservation.Application.Repository.Reservation.Dtos.Request;
using Reservation.Application.Repository.TripUser.Dtos.Responses;
using Reservation.Core.Helpers.TripUser;

namespace Reservation.Application.Repository.TripUser
{
    public class TripUserMapper : Profile
    {
        public TripUserMapper()
        {
            //Create
            CreateMap<Core.Entities.TripUser, CreateTripUserCommand>()
                .ForMember(d=>d.TripId,s=>s.MapFrom(a=>a.TripId))
                .ForMember(d=>d.UserId,s=>s.MapFrom(a=>a.UserId))
                .ReverseMap();

            CreateMap<Core.Entities.TripUser, CreateTripUserResponse>()
                .ForMember(d => d.TripId, s => s.MapFrom(a => a.TripId))
                .ForMember(d => d.UserId, s => s.MapFrom(a => a.UserId))
                .ReverseMap();
        }
    }
}
