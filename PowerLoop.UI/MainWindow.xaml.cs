// <copyright file="MainWindow.xaml.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.UI
{
    using System.Windows;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow(ServiceProvider serviceProvider)
        {
            this.InitializeComponent();

            // Add for the webview
            this.WebView.Services = serviceProvider;

            this.DataContext = serviceProvider.GetRequiredService<MainWindowViewModel>();
        }
    }
}
