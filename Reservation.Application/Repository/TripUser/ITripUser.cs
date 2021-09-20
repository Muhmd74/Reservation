using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Reservation.Application.Commands.TripUserCommand;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.TripUser.Dtos.Responses;

namespace Reservation.Application.Repository.TripUser
{
    public interface ITripUser
    {
        Task<OutputResponse<CreateTripUserResponse>> CreateTripUser(CreateTripUserCommand model);
        Task<OutputResponse<List<GetUsersName>>> SearchUsers(string name);
        Task<OutputResponse<bool>> Delete(Guid userId, Guid tripId);

    }
}
