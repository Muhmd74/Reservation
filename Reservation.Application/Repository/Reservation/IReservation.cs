﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Reservation.Application.Repository.Reservation.Dtos.Request;
using Reservation.Application.Repository.Reservation.Dtos.Responses;

namespace Reservation.Application.Repository.Reservation
{
    public interface IReservation
    {
        Task<CreateReservationRequest> CreateReservation(CreateReservationRequest model);
        Task <List<ReservationResponses>> GetAllReservation();
        Task<ReservationResponses> GetByReservationId(Guid id);

    }
}
