using System;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System.Windows;

using MedApp.Services;
using MedApp.ViewModels;
using MedApp.Data;

namespace MedApp
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {

        private static IHost? _host;
        public static IHost Host => _host
            ??= Program.CreateHostBuilder(Environment.GetCommandLineArgs()).Build();


        /// <summary>
        /// Access for services
        /// </summary>
        public static IServiceProvider Services => Host.Services;


        /// <summary>
        /// Here is all services' configurations
        /// </summary>
        internal static void ConfigureServices(HostBuilderContext host, IServiceCollection services) => services
            .AddServices() //From services registrator
            .AddViewModels() //From viewmodels registrator
            .AddDatabase(host.Configuration.GetSection("Database"))
            ; //From db registrator

        #region Startup/Exit override
        protected override async void OnStartup(StartupEventArgs e)
        {
            //using (var scope = Services.CreateScope())
            //{
            //    await scope.ServiceProvider.GetRequiredService<DbInitializer>().InitializeAsync();
            //}

            var host = Host;
            base.OnStartup(e);
            await host.StartAsync();
        }

        protected override async void OnExit(ExitEventArgs e)
        {
            using var host = Host;
            base.OnExit(e);
            await host.StopAsync();
        }
        #endregion
    }
}
