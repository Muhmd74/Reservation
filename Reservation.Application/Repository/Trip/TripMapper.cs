using System;
using System.Web;
using AutoMapper;
using Reservation.Application.Commands.TripCommand;
using Reservation.Application.Repository.Trip.Dtos.Request;
using Reservation.Application.Repository.Trip.Dtos.Responses;

namespace Reservation.Application.Repository.Trip
{
    public class TripMapper : Profile
    {
        public TripMapper()
        {
            //create
            CreateMap<Core.Entities.Trip, CreateTripCommand>()
                        .ForMember(d => d.Content,
                    s =>
                        s.MapFrom(a => HttpUtility.HtmlEncode(a.Content))
                ).ReverseMap();

            CreateMap<Core.Entities.Trip, CreateTripRequest>()
                .ForMember(d => d.DateTime,
                    s => s.MapFrom(a => a.DateTime == DateTime.Now))
                 .ForMember(d => d.Content,
                    s =>
                        s.MapFrom(a => HttpUtility.HtmlEncode(a.Content))
                ).ReverseMap();

            //Update
            CreateMap< UpdateTripCommand, Core.Entities.Trip>()
                      .ForMember(d => d.Price, s => s.MapFrom(a => a.Price == 0))
                .ForMember(d => d.Content,
                    s =>
                        s.MapFrom(a => HttpUtility.HtmlEncode(a.Content))
                )
                .ReverseMap();

            //GetList
            CreateMap<Core.Entities.Trip, TripResponses>()
                .ForMember(d => d.Content,
                    s => s.MapFrom(a => a.Content != null
                        ? HttpUtility.HtmlDecode(a.Content)
                        : a.Content))
                .ReverseMap();
            //GetDetails
            CreateMap<Core.Entities.Trip, TripDetailsResponses>()
                .ForMember(d => d.Content,
                    s => s.MapFrom(a => a.Content != null
                        ? HttpUtility.HtmlDecode(a.Content)
                        : a.Content))
                .ReverseMap();
        }

    }
}
