using AutoMapper;
using Reservation.Application.Commands.TripUserCommand;
using Reservation.Application.Repository.TripUser.Dtos.Responses;

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

            //GetName
            CreateMap<Core.Entities.ApplicationUser, GetUsersName>()
                .ForMember(d => d.UserId, s => s.MapFrom(a => a.Id))
                .ReverseMap();
        }
    }
}
