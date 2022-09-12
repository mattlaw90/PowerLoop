// <copyright file="MainWindow.xaml.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.UI
{
    using System.Windows;
    using Microsoft.Extensions.DependencyInjection;
    using PowerLoop.UI.Play;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel mainWindowViewModel;
        private readonly PlayViewModel playViewModel;

        public MainWindow(
            ServiceProvider serviceProvider,
            MainWindowViewModel mainWindowViewModel,
            PlayViewModel playViewModel)
        {
            this.InitializeComponent();

            // Add for the webview
            this.Resources.Add("services", serviceProvider);

            this.mainWindowViewModel = mainWindowViewModel;
            this.playViewModel = playViewModel;

            this.DataContext = this.mainWindowViewModel;
        }

        private void CloseCommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            // if (MessageBox.Show("Close?", "Close", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            this.playViewModel.Stop();
            this.mainWindowViewModel.OnStop();
        }
    }
}
