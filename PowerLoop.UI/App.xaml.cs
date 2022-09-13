// <copyright file="App.xaml.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.UI
{
    using System.Windows;
    using Microsoft.Extensions.DependencyInjection;
    using MudBlazor;
    using MudBlazor.Services;
    using PowerLoop.UI.Play;
    using PowerLoop.UI.Settings;
    using PowerLoop.UI.Settings.Commands;
    using PowerLoop.UI.Settings.Queries;

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
            services.AddSingleton<GetSettings>();
            services.AddSingleton<SaveSettings>();

            // Add ViewModels as singletons - no need for more than one of each
            services.AddSingleton<MainWindowViewModel>();
            services.AddSingleton<PlayViewModel>();
            services.AddSingleton<SettingsViewModel>();

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
