﻿using System;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservation.WebApi.Setups.Factory.Services;

namespace Reservation.WebApi.Setups.Services
{
    public static class InstallerExtensions
    {
        public static void InstallServicessInAssembly(this IServiceCollection services, IConfiguration configuration)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>
                typeof(IServiceSetup).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IServiceSetup>().ToList();

            installers.ForEach(installer => installer.InstallServices(services, configuration));
        }
    }
}
