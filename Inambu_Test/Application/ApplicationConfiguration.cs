using Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace Application
{
    public static class ApplicationConfiguration
    {
        public static void ConfigureApplication(this IServiceCollection services, IConfiguration configuration)
        {
            // Register MediatR and scan the Application assembly for handlers
            services.AddMediatR(cfg => cfg.RegisterServicesFromAssembly(typeof(ApplicationConfiguration).Assembly));

            // Configure Infrastructure services
            services.ConfigureInfrastructure(configuration);
        }
    }
}
