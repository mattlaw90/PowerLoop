// <copyright file="App.xaml.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.UI
{
    using System.Windows;
    using Microsoft.Extensions.DependencyInjection;
    using MudBlazor.Services;
    using PowerLoop.UI.Play;
    using PowerLoop.UI.Settings;

    /// <summary>
    /// Interaction logic for App.xaml.
    /// </summary>
    public partial class App : Application
    {
        private ServiceProvider serviceProvider;

        public App()
        {
            this.ConfigureServices();
        }

        private void ConfigureServices()
        {
            var services = new ServiceCollection();

            services.AddSingleton<ISettingsReader>(s => new SettingsReader("config.json", "AppSettings"));

            // Add Blazor
            services.AddWpfBlazorWebView();
            services.AddBlazorWebViewDeveloperTools();

            // Add Mud
            services.AddMudServices();

            // Add ViewModels
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<PlayViewModel>();

            this.serviceProvider = services.BuildServiceProvider();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindow(
                this.serviceProvider,
                this.serviceProvider.GetRequiredService<MainWindowViewModel>(),
                this.serviceProvider.GetRequiredService<PlayViewModel>());
            mainWindow.Show();
        }
    }
}
