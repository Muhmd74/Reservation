using System;
using System.Collections.Generic;
using System.Text;
using System.Web;
using AutoMapper;
using Reservation.Application.Commands;
using Reservation.Application.Commands.ReservationCommand;
using Reservation.Application.Repository.Reservation.Dtos.Request;
using Reservation.Application.Repository.Reservation.Dtos.Responses;
using Reservation.Core.Entities;
using Reservation.Core.Interface;

namespace Reservation.Application.Repository.Reservation
{
    public class ReservationMapper : Profile
    {
        public ReservationMapper()
        {
            //create
            CreateMap<Trip, CreateReservationCommand>()
                .ForMember(d => d.DateTime,
                    s => s.MapFrom(a => a.DateTime == DateTime.Now))
                .ForMember(d => d.Price, s => s.MapFrom(a => a.Price == 0))
                .ForMember(d => d.Content,
                    s =>
                        s.MapFrom(a => HttpUtility.HtmlEncode(a.Content))
                ).ReverseMap();

            CreateMap<Trip, CreateReservationRequest>()
                .ForMember(d => d.DateTime,
                    s => s.MapFrom(a => a.DateTime == DateTime.Now))
                .ForMember(d => d.Price, s => s.MapFrom(a => a.Price == 0))
                .ForMember(d => d.Content,
                    s =>
                        s.MapFrom(a => HttpUtility.HtmlEncode(a.Content))
                ).ReverseMap();

            //GetList
            CreateMap<Trip, ReservationResponses>()
                .ForMember(d => d.Content,
                    s => s.MapFrom(a => a.Content != null
                        ? HttpUtility.HtmlDecode(a.Content)
                        : a.Content))
                .ReverseMap();
            //GetDetails
            CreateMap<Trip, ReservationDetailsResponses>()
                .ForMember(d => d.Content,
                    s => s.MapFrom(a => a.Content != null
                        ? HttpUtility.HtmlDecode(a.Content)
                        : a.Content))
                .ReverseMap();
        }

    }
}
