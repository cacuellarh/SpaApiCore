using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Nanis.Shared;
using Nanis.Shared.Factory;
using Spa.Infraestructure.Persistence;
using System.Reflection;

namespace Spa.Infraestructure
{
    public static class InfraestructureServicesRegistration
    {
        public static IServiceCollection AddInfraestructureService(this IServiceCollection services, IConfiguration configuration)
        {
            var connectionString = configuration.GetConnectionString("ConnectionString");
            services.AddDbContext<SpaContext>(options =>
                options.UseMySql(connectionString, ServerVersion.AutoDetect(connectionString))
                );

            services.AddScoped<IRepositoryFactory>(provider =>
            {
                var applicationAssembly = Assembly.Load("Spa.Application");
                var dbContext = provider.GetRequiredService<SpaContext>();
                return new RepositoryFactory(applicationAssembly, dbContext);
            });

            services.AddScoped<IUnitOfWork>(provider => {
                var dbContext = provider.GetRequiredService<SpaContext>();
                var factory = provider.GetRequiredService<IRepositoryFactory>();
                return new UnitOfWork(dbContext, factory);
            });
     
            return services;
        }
    }
}
