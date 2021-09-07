using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservation.Application.Common.Files;
using Reservation.Application.Repository.Trip;
using Reservation.Application.Repository.TripUser;
using Reservation.Application.Repository.User;
using Reservation.WebUI.Factory.Services;

namespace Reservation.WebUI.Services
{
    public class DependencyServiceSetup : IServiceSetup
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            //services.AddScoped<ITrip, TripServices>();
            //services.AddScoped<ITripUser, TripUserServices>();
            //services.AddScoped<IUser, UserServices>();
            //File
            services.AddScoped<FileService>();
            services.AddScoped<UploadCore>();
        }
    }
}
