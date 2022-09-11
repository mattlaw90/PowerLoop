// <copyright file="PlayWindow.xaml.cs" company="Matthew Law">
// Copyright (c) Matthew Law. All rights reserved.
// </copyright>

namespace PowerLoop
{
    using System.Windows;

    /// <summary>
    /// Interaction logic for PlayWindow.xaml.
    /// </summary>
    public partial class PlayWindow : Window
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="PlayWindow"/> class.
        /// </summary>
        public PlayWindow(PlayViewModel playViewModel)
        {
            this.InitializeComponent();

            this.DataContext = playViewModel;
        }

        private void CloseCommandBinding_Executed(object sender, System.Windows.Input.ExecutedRoutedEventArgs e)
        {
            // if (MessageBox.Show("Close?", "Close", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            this.Close();
        }
    }
}
