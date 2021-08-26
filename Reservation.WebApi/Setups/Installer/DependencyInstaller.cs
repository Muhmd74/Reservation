﻿using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservation.Application.Repository.Reservation;

namespace Reservation.WebApi.Setups.Installer
{
    public class DependencyInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IReservation, ReservationServices>();
        }
    }
}
