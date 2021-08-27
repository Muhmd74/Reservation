using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservation.Application.Repository.Trip;
using Reservation.Application.Repository.TripUser;
using Reservation.Application.Repository.User;
using Reservation.Core.Interface;
using Reservation.WebApi.Setups.Factory.Services;

namespace Reservation.WebApi.Setups.Services
{
    public class AutoMapperServiceSetup : IServiceSetup
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddAutoMapper(typeof(Startup));
            services.AddAutoMapper(a =>
            {
                a.AddProfile<TripMapper>();
                a.AddProfile<TripUserMapper>();
                a.AddProfile<UserMapper>();
            });

        }
    }
    
}
