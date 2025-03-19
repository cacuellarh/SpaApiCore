using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Serilog;

namespace Spa.Application
{
    public static class ApplicationServicesRegistration
    {
        public static IServiceCollection AddApplicationServiceCollection(this IServiceCollection services,
            IConfiguration configuration)
        {
            Log.Logger = new LoggerConfiguration()
            .WriteTo.File(configuration.GetConnectionString("LoggerPath"),      // Ruta del archivo de logs
                  rollingInterval: RollingInterval.Day, // Crea un archivo nuevo cada día
                  retainedFileCountLimit: 7)            // Guarda logs de los últimos 7 días
            .CreateLogger();
            Console.WriteLine("asdas");
            services.AddAutoMapper(typeof(MappingProfile).Assembly);

            return services;
        }
    }
}
