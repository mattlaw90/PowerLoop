// <copyright file="MainWindow.xaml.cs" company="Matthew Law">
// Copyright (c) Matthew Law. All rights reserved.
// </copyright>

namespace PowerLoop
{
    using System.Windows;
    using Microsoft.Extensions.DependencyInjection;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            this.InitializeComponent();

            // Add service collection for blazor
            this.Resources.Add("services", App.Current.Properties[nameof(App.ServiceProvider)]);
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            //var playWindow = new PlayWindow(this.playViewModel);

            //if (playWindow != null)
            //{
            //    _ = playWindow.ShowDialog();
            //    this.playViewModel.Start();
            //}
        }
    }
}
