using MedApp.Services.Interfaces;
using MedData.Entities;
using Microsoft.Extensions.DependencyInjection;

namespace MedApp.Services
{
    static class ServicesRegistrator
    {
        public static IServiceCollection AddServices(this IServiceCollection services) => services
            .AddSingleton<IMessageService, MessageService>()
            .AddTransient<IAuthService, AuthService>()
            .AddTransient<IPatientsService, PatientService>()
            .AddTransient<IWindowService, WindowService>()
            .AddTransient<IEntitiesCollectionProvider<Department>,  EntityCollectionProvider<Department>>()
            .AddTransient<IEntitiesCollectionProvider<Position>,  EntityCollectionProvider<Position>>()
            .AddTransient<IEntitiesCollectionProvider<User>,  EntityCollectionProvider<User>>()
            .AddTransient<IEntitiesCollectionProvider<Chamber>,  EntityCollectionProvider<Chamber>>()
            .AddTransient<IEntitiesCollectionProvider<Cabinet>,  EntityCollectionProvider<Cabinet>>()
            .AddTransient<IEntitiesCollectionProvider<Mkb>,  EntityCollectionProvider<Mkb>>()
        ;
    }
}
