using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using FluentValidation.AspNetCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservation.WebApi.Setups.Filters;

namespace Reservation.WebApi.Setups.Installer
{
    public class FluentValidationInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddMvc(options => options.Filters.Add<ValidatorActionFilter>());
            //.AddFluentValidation(options =>
            //    options.RegisterValidatorsFromAssemblyContaining<AddNewDefinitionRequestValidator>());
        }
    }
}
