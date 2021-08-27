using System;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservation.Application.Common.Files;
using Reservation.Application.Repository.Trip;
using Reservation.Application.Repository.TripUser;
using Reservation.Application.Repository.User;

namespace Reservation.WebApi.Setups.Installer
{
    public class DependencyInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITrip, TripServices>();
            services.AddScoped<ITripUser, TripUserServices>();
            services.AddScoped<IUser, UserServices>();
            //File
            services.AddScoped<FileService>();
            services.AddScoped<UploadCore>();
        }
    }
}
