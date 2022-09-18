// <copyright file="MainWindowViewModel.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop
{
    using System.Windows;
    using System.Windows.Input;
    using CommunityToolkit.Mvvm.ComponentModel;
    using CommunityToolkit.Mvvm.Input;
    using PowerLoop.Play;
    using ResizeMode = System.Windows.ResizeMode;

    public class MainWindowViewModel : ObservableObject, IMainWindowViewModel
    {
        private readonly IPlayViewModel playViewModel;
        private WindowState currentWindowState = WindowState.Normal;
        private WindowStyle currentWindowStyle = WindowStyle.SingleBorderWindow;
        private ResizeMode currentResizeMode = ResizeMode.CanResize;
        private bool isTopmost;
        private Visibility currentVisibility = Visibility.Visible;
        private RelayCommand<KeyEventArgs> onKeyDownCommand;

        public MainWindowViewModel(IPlayViewModel playViewModel)
        {
            this.playViewModel = playViewModel;
        }

        /// <inheritdoc/>
        public WindowState CurrentWindowState { get => this.currentWindowState; set => this.SetProperty(ref this.currentWindowState, value); }

        /// <inheritdoc/>
        public WindowStyle CurrentWindowStyle { get => this.currentWindowStyle; set => this.SetProperty(ref this.currentWindowStyle, value); }

        /// <inheritdoc/>
        public ResizeMode CurrentResizeMode { get => this.currentResizeMode; set => this.SetProperty(ref this.currentResizeMode, value); }

        /// <inheritdoc/>
        public bool IsTopmost { get => this.isTopmost; set => this.SetProperty(ref this.isTopmost, value); }

        /// <inheritdoc/>
        public Visibility CurrentVisibility { get => this.currentVisibility; set => this.SetProperty(ref this.currentVisibility, value); }

        /// <inheritdoc/>
        public ICommand OnKeyDownCommand => this.onKeyDownCommand ??= new RelayCommand<KeyEventArgs>(this.OnKeyDown);

        /// <inheritdoc/>
        public void OnPlay()
        {
            // Hide before changes
            this.CurrentVisibility = Visibility.Collapsed;

            // Make topmost, maximized, remove style and set resize to none
            //// Note the order is here is important. ResizeMode must be set first to cover the taskbar!
            this.CurrentResizeMode = ResizeMode.NoResize;
            this.CurrentWindowState = WindowState.Maximized;
            this.CurrentWindowStyle = WindowStyle.None;
            this.IsTopmost = true;

            // Show after changes
            this.CurrentVisibility = Visibility.Visible;
        }

        /// <inheritdoc/>
        public void OnStop()
        {
            this.IsTopmost = false;
            this.CurrentWindowState = WindowState.Normal;
            this.CurrentWindowStyle = WindowStyle.SingleBorderWindow;
            this.CurrentResizeMode = ResizeMode.CanResize;
        }

        private void OnKeyDown(KeyEventArgs? args)
        {
            // Only try and stop on key down if playing
            if (this.playViewModel.IsPlaying &&
                this.playViewModel.OnTryStop(args))
            {
                this.OnStop();
            }
        }
    }
}
