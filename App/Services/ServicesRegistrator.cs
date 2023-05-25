using MedApp.Services.Interfaces;
using Microsoft.Extensions.DependencyInjection;

namespace MedApp.Services
{
    static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
        .AddTransient<IAuthService, AuthService>()
        .AddTransient<IDepartmentProvider,  DepartmentProvider>()
        ;
    }
}
