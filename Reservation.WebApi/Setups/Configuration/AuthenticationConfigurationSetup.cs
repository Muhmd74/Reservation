using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Reservation.WebApi.Setups.Factory.Configurations;

namespace Reservation.WebApi.Setups.Configuration
{
    public class AuthenticationConfigurationSetup : IConfigurationSetup
    {
        public void SetupConfiguration(IApplicationBuilder app)
        {
            app.UseAuthentication();
            app.UseAuthorization();
        }
    }
}
