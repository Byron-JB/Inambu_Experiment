using Infrastructure.Perisitence;
using Infrastructure.Persistence;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Implementation = Infrastructure.Persistence.Repository.Implementation;
using Interface = Infrastructure.Persistence.Repository.Interface;

namespace Infrastructure
{
    public static class InfrastructureConfiguration
    {
        public static void ConfigureInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            // Add infrastructure services here, e.g., DbContext, repositories, etc.

            services.AddDbContextFactory<Persistence.ApplicationDbContext>(options =>
            {
                options.UseSqlServer(
                    configuration.GetConnectionString("DefaultConnection"),
                    b => b.MigrationsAssembly(typeof(ApplicationDbContext).Assembly.FullName)
                );

            });

            //services.AddTransient<ApplicationDBInitializer>();
            services.AddTransient<Interface.IProductionLine, Implementation.ProductionLine>();
            services.AddTransient<Interface.IUser, Implementation.User>();
            services.AddTransient<Interface.IMeasurement, Implementation.Measurement>();
            services.AddTransient<Interface.IExpenditureRequest, Implementation.ExpenditureRequest>();
            services.AddTransient<Interface.IExpenditureApprovalMembers, Implementation.ExpenditureApprovalMembers>();
            services.AddScoped<ApplicationDBInitializer>();

        }
    }
}
