using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservation.Infrastructure.Data.ApplicationDbContext;
using Reservation.WebUI.Factory.Services;

namespace Reservation.WebUI.Services
{
    public class DatabaseServiceSetup : IServiceSetup
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<ApplicationDbContext>();
        }
    }
}
