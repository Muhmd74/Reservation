﻿using System;
using System.Linq;
using Microsoft.AspNetCore.Builder;

namespace Reservation.WebUI.Factory.Configurations
{
    public static class ConfigurationSetupExtension
    {
        public static void InstallConfigureInAssembly(this IApplicationBuilder app, IApplicationBuilder applicationBuilder)
        {
            var installers = typeof(Startup).Assembly.ExportedTypes.Where(x =>
                typeof(IConfigurationSetup).IsAssignableFrom(x) && !x.IsInterface && !x.IsAbstract).Select(Activator.CreateInstance).Cast<IConfigurationSetup>().ToList();

            installers.ForEach(installer => installer.SetupConfiguration(app));
        }
    }
}
