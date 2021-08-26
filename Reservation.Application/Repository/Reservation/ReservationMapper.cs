using System;
using System.Collections.Generic;
using System.Text;
using AutoMapper;
using Reservation.Application.Repository.Reservation.Dtos.Responses;
using Reservation.Core.Entities;
using Reservation.Core.Interface;

namespace Reservation.Application.Repository.Reservation
{
    public class ReservationMapper : Profile  
    {
        public ReservationMapper()
        {
            CreateMap<Trip, ReservationResponses>()
                .ReverseMap();
        }

    }
}
