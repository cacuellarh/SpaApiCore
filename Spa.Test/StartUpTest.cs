using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Nanis.Shared.Factory;
using Nanis.Shared;
using System.Reflection;
using Spa.Infraestructure.Persistence;

namespace Spa.Test
{
    public abstract class StartUpTest
    {
        protected ServiceProvider Provider { get; private set; }
        protected IUnitOfWork unitOfWork { get; private set; }
        public StartUpTest()
        {
            var services = new ServiceCollection();

            services.AddDbContext<SpaContext>(options =>
                options.UseSqlServer(@"Server=ECOPE-CACUELLAR\SQLEXPRESS;Database=Spa;Trusted_Connection=True;Encrypt=False;ConnectRetryCount=0")
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

            Provider = services.BuildServiceProvider();

            unitOfWork = Provider.GetRequiredService<IUnitOfWork>();
        }
    }
}
