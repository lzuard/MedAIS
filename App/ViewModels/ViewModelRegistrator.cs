using Microsoft.Extensions.DependencyInjection;
using System.Runtime.CompilerServices;

namespace MedApp.ViewModels
{
    static class ViewModelRegistrator
    {
        public static IServiceCollection AddViewModels(this IServiceCollection services) => services
            .AddSingleton<MainWindowViewModel>()
            .AddSingleton<DebugWindowViewModel>()
            .AddSingleton<AuthViewModel>()
            .AddSingleton<DoctorsViewModel>()
            .AddSingleton<PatientViewModel>()
            ;
    }
}
