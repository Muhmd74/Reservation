using Microsoft.AspNetCore.Builder;

namespace Reservation.WebUI.Factory.Configurations
{
    public interface IConfigurationSetup
    {
        void SetupConfiguration(IApplicationBuilder app);
    }
}
