// <copyright file="App.xaml.cs" company="Matthew Law">
// Copyright (c) Matthew Law. All rights reserved.
// </copyright>

namespace PowerLoop
{
    using System.Windows;
    using Microsoft.Extensions.DependencyInjection;
    using PowerLoop.Play;
    using PowerLoop.Settings;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        public ServiceProvider ServiceProvider;

        public App()
        {
            this.ConfigureServices();
        }

        private void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ISettingsReader>(s => new SettingsReader("config.json", "AppSettings"));

            services.AddScoped<MainWindowViewModel>();
            services.AddScoped<PlayViewModel>();
            services.AddScoped<PlayWindow>();
            services.AddWpfBlazorWebView();

            this.ServiceProvider = services.BuildServiceProvider();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindow();
            mainWindow.Show();
        }
    }
}
