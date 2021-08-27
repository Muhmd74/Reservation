using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservation.Application.Repository.Reservation;
using Reservation.Application.Repository.TripUser;
using Reservation.Application.Repository.User;

namespace Reservation.WebApi.Setups.Installer
{
    public class DependencyInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<IReservation, ReservationServices>();
            services.AddScoped<ITripUser, TripUserServices>();
            services.AddScoped<IUser, UserServices>();
        }
    }
}
