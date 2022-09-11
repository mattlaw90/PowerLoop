// <copyright file="MainWindow.xaml.cs" company="Matthew Law">
// Copyright (c) Matthew Law. All rights reserved.
// </copyright>

namespace PowerLoop
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for MainWindow.xaml.
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly PlayViewModel playViewModel;

        public MainWindow(MainWindowViewModel mainWindowViewModel, PlayViewModel playViewModel)
        {
            this.InitializeComponent();

            this.DataContext = mainWindowViewModel;
            this.playViewModel = playViewModel;
        }

        private void Play_Click(object sender, RoutedEventArgs e)
        {
            var playWindow = new PlayWindow(this.playViewModel);
            var closed = playWindow.ShowDialog();
        }
    }
}
