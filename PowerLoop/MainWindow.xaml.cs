// <copyright file="MainWindow.xaml.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop
{
    using System;
    using System.IO;
    using System.Windows;
    using Microsoft.Extensions.DependencyInjection;
    using PowerLoop.AppConfig;
    using PowerLoop.Play;
    using PowerLoop.Settings.Models;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly string virtualHost;

        public MainWindow(ServiceProvider serviceProvider)
        {
            // Allow auto play on videos in webview2
            Environment.SetEnvironmentVariable("WEBVIEW2_ADDITIONAL_BROWSER_ARGUMENTS", "--autoplay-policy=no-user-gesture-required");

            this.InitializeComponent();

            // Set webview service provider
            this.WebView.Services = serviceProvider;

            // Register the webview2 cycle to the play view model cycling
            // This enables use of local files by setting a virtual host name for the folder path
            var playViewModel = serviceProvider.GetRequiredService<IPlayViewModel>();
            playViewModel.Cycling += this.PlayViewModel_Cycling;

            var config = serviceProvider.GetRequiredService<IConfig>();
            this.virtualHost = config.VirtualHost;

            this.DataContext = serviceProvider.GetRequiredService<IMainWindowViewModel>();
        }

        private void PlayViewModel_Cycling(ILoopItem item)
        {
            // For each media item, split the folder and file name
            FileInfo itemFile = new (item.Path);
            var folder = itemFile.DirectoryName ?? itemFile.FullName;

            // Set the fake https name for the item
            // Set webview access permissions for local files
            this.WebView.WebView.CoreWebView2.SetVirtualHostNameToFolderMapping(
                this.virtualHost,
                folder,
                Microsoft.Web.WebView2.Core.CoreWebView2HostResourceAccessKind.Allow);

            // Reload the page for virtual host name
            this.WebView.WebView.Reload();
        }
    }
}
