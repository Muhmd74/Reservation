using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Reservation.Application.Commands;
using Reservation.Application.Common.Response;
using Reservation.Application.Repository.TripUser.Dtos.Responses;
using Reservation.Core.Helpers.TripUser;

namespace Reservation.Application.Repository.TripUser
{
    public interface ITripUser
    {
        Task<OutputResponse<CreateTripUserResponse>> CreateTripUser(CreateTripUserCommand model);
    }
}
