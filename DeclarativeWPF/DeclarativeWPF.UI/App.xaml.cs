using System;
using System.Windows;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace DeclarativeWPF.UI
{
    public partial class App : Application
    {
        private static IHost? _hosting;

        private bool _isHostingDisposed;

        private static IHost Hosting => _hosting ??= CreateHostBuilder(Environment.GetCommandLineArgs()).Build();

        protected override async void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            await Hosting.StartAsync();

            this.Exit += DisposeHosting;
            this.DispatcherUnhandledException += DisposeHosting;
            this.SessionEnding += DisposeHosting;
        }

        public static IHostBuilder CreateHostBuilder(string[] args) => Host
            .CreateDefaultBuilder(args)
            .ConfigureServices(ConfigureServices);

        private void DisposeHosting(object sender, EventArgs e)
        {
            this.Exit -= DisposeHosting;
            this.DispatcherUnhandledException -= DisposeHosting;
            this.SessionEnding -= DisposeHosting;

            if (_isHostingDisposed) return;
            _isHostingDisposed = true;
            using var host = Hosting;
            host.StopAsync(TimeSpan.FromSeconds(5)).Wait();
        }

        private static void ConfigureServices(HostBuilderContext arg1, IServiceCollection arg2)
        {
        }
    }
}
