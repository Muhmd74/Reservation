using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Reservation.Application.Common.Authentication;
using Reservation.Application.Common.Files;
using Reservation.Application.Repository.Category;
using Reservation.Application.Repository.City;
using Reservation.Application.Repository.Country;
using Reservation.Application.Repository.Trip;
using Reservation.Application.Repository.TripUser;
using Reservation.WebApi.Setups.Factory.Services;

namespace Reservation.WebApi.Setups.Services
{
    public class DependencyServiceSetup : IServiceSetup
    {
        public void InstallServices(IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ITrip, TripServices>();
            services.AddScoped<ITripUser, TripUserServices>();
            services.AddScoped<ICountry, CountryService>();
            services.AddScoped<ICity, CityService>();
            services.AddScoped<ICategory, CategoryService>();
             services.AddScoped<JwtTokenConfig>();
            //File
            services.AddScoped<FileService>();
            services.AddScoped<UploadCore>();

           

        }
    }
}
