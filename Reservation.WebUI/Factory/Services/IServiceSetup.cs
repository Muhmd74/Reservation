using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Reservation.WebUI.Factory.Services
{
    public interface IServiceSetup
    {
        void InstallServices(IServiceCollection services, IConfiguration configuration);
    }
}
