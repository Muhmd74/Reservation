using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation;
using FluentValidation.AspNetCore;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservation.WebApi.Setups.Factory.Services;
using Reservation.WebApi.ValidFilter;

namespace Reservation.WebApi.Setups.Services
{
    public class FluentValidationInstaller : IServiceSetup
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc(options =>
                {
                    options.EnableEndpointRouting = false;
                    options.Filters.Add<ValidatorActionFilter>();
                }).AddFluentValidation(options =>
                    options.RegisterValidatorsFromAssemblyContaining<Startup>())
                .SetCompatibilityVersion(CompatibilityVersion.Version_3_0);
        }

     
    }
}
