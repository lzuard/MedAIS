using MedData.Data;
using MedData.Repositories.Base;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace MedApp.Data
{
    internal static class DbRegistrator
    {
        public static IServiceCollection AddDatabase(this IServiceCollection services, IConfiguration configuration) => services
            .AddSingleton<ApplicationContext>(serviceProvider =>
            {
                var optionsBuilder = new DbContextOptionsBuilder<ApplicationContext>();
                optionsBuilder.UseNpgsql(configuration.GetConnectionString("Postgres"));
                return new ApplicationContext(optionsBuilder.Options);
            })
            .AddRepositoriesInDb()
            ;
            //.AddDbContext<ApplicationContext>(opt =>
            //{
            //    opt.UseNpgsql(configuration.GetConnectionString("Postgres"));
            //})

            //.AddTransient<DbInitializer>()
            //;
    }
}
