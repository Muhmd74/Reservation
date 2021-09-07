using Microsoft.AspNetCore.Builder;
using Reservation.WebUI.Factory.Configurations;

namespace Reservation.WebUI.Configuration
{
    public class InitialProjectConfigurationSetup : IConfigurationSetup
    {
        public void SetupConfiguration(IApplicationBuilder app)
        {
            app.UseRouting();
            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
