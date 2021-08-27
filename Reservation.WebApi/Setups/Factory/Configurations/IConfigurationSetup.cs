using Microsoft.AspNetCore.Builder;

namespace Reservation.WebApi.Setups.Factory.Configurations
{
    public interface IConfigurationSetup
    {
        void SetupConfiguration(IApplicationBuilder app);
    }
}
