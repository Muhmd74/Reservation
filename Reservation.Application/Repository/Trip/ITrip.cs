using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reservation.Application.Commands.TripCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.Trip.Dtos.Responses;

namespace Reservation.Application.Repository.Trip
{
    public interface ITrip
    {
        Task<OutputResponse<TripResponses>> CreateTrip(CreateTripCommand model);
        Task<OutputResponse<List<TripResponses>>> GetAllTrip(int pageSize=Int32.MaxValue);
        Task<OutputResponse<List<TripResponses>>> GetAllTripDeleted(int pageSize = Int32.MaxValue);

        Task<OutputResponse<TripResponses>> GetByTripId(Guid id);
        Task<OutputResponse<TripResponses>> UpdateTrip(UpdateTripCommand model);

        Task<OutputResponse<bool>> DeleteOrRestore(Guid id);


    }
}
