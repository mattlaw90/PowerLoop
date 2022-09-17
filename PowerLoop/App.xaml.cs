// <copyright file="App.xaml.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop
{
    using System;
    using System.IO;
    using System.Windows;
    using Microsoft.Extensions.DependencyInjection;
    using MudBlazor;
    using MudBlazor.Services;
    using PowerLoop.Logging;
    using PowerLoop.Play;
    using PowerLoop.Settings;
    using PowerLoop.Settings.Commands;
    using PowerLoop.Settings.Queries;

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

            // Add Blazor
            services.AddWpfBlazorWebView();
            services.AddBlazorWebViewDeveloperTools();

            // Add system config
            services.AddScoped(s => new Config()
            {
                AppSettingsPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "PowerLoop",
                    "appsettings.json"),

                LogPath = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData),
                    "PowerLoop",
                    "log.txt"),

                VirtualHost = "my-powerloop",
            });

            // Add Mud
            services.AddMudServices(c =>
            {
                c.SnackbarConfiguration.PositionClass = Defaults.Classes.Position.BottomRight;
                c.SnackbarConfiguration.PreventDuplicates = false;
                c.SnackbarConfiguration.NewestOnTop = true;
                c.SnackbarConfiguration.ShowCloseIcon = true;
                c.SnackbarConfiguration.VisibleStateDuration = 10000;
                c.SnackbarConfiguration.HideTransitionDuration = 500;
                c.SnackbarConfiguration.ShowTransitionDuration = 500;
                c.SnackbarConfiguration.SnackbarVariant = Variant.Filled;
            });

            // Add queries/commands
            services.AddScoped<BrowseFile>();
            services.AddScoped<GetSettings>();
            services.AddScoped<SaveSettings>();

            // Add ViewModels as singletons - no need for more than one of each
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<PlayViewModel>();
            services.AddSingleton<SettingsViewModel>();

            // Add AppLogger once
            services.AddSingleton<AppLogger>();

            this.serviceProvider = services.BuildServiceProvider();
        }

        private void OnStartup(object sender, StartupEventArgs e)
        {
            var mainWindow = new MainWindow(this.serviceProvider);

            mainWindow.Show();
        }
    }
}
