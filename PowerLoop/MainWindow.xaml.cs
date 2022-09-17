// <copyright file="MainWindow.xaml.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop
{
    using System;
    using System.IO;
    using System.Windows;
    using Microsoft.Extensions.DependencyInjection;
    using PowerLoop.Play;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PlayViewModel playViewModel;

        public MainWindow(ServiceProvider serviceProvider)
        {
            // Allow auto play on videos in webview2
            Environment.SetEnvironmentVariable("WEBVIEW2_ADDITIONAL_BROWSER_ARGUMENTS", "--autoplay-policy=no-user-gesture-required");

            this.InitializeComponent();

            // Set webview service provider
            this.WebView.Services = serviceProvider;

            // Set the fake https name for the item
            this.playViewModel = serviceProvider.GetRequiredService<PlayViewModel>();
            this.playViewModel.Cycling += this.PlayViewModel_Cycling;

            this.DataContext = serviceProvider.GetRequiredService<MainWindowViewModel>();
        }

        private void PlayViewModel_Cycling(Settings.LoopItem item)
        {
            // For each media item, split the folder and file name
            FileInfo itemFile = new (item.Path);
            var folder = itemFile.DirectoryName ?? itemFile.FullName;

            // Set webview access permissions for local files
            this.WebView.WebView.CoreWebView2.SetVirtualHostNameToFolderMapping(
                "local-powerloop",
                folder,
                Microsoft.Web.WebView2.Core.CoreWebView2HostResourceAccessKind.Allow);

            // Reload the page for virtual host name
            this.WebView.WebView.Reload();
        }
    }
}
