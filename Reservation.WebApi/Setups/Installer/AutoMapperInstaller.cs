using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservation.Application.Repository.Reservation;
using Reservation.Core.Interface;

namespace Reservation.WebApi.Setups.Installer
{
    public class AutoMapperInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(a =>
            {
                a.AddProfile<ReservationMapper>();
            });

        }
    }
    
}
