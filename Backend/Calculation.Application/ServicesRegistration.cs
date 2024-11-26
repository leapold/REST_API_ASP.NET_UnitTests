using Calculation.Application.Services;
using Microsoft.Extensions.DependencyInjection;


namespace Calculation.Application
{
    public static class ServicesRegistration
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IVehicleService, VehicleService>();
            return services;
        }
    }
}
