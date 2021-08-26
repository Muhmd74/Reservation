using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.FileProviders;

namespace Reservation.WebApi.Installer
{
    public class FileToolsInstaller : IInstaller
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddSingleton<IFileProvider>(new PhysicalFileProvider(
                Path.Combine(Directory.GetCurrentDirectory(), "wwwroot")));
            services.AddHttpContextAccessor();
        }
    }
}
