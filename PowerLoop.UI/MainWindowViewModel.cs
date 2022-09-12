// <copyright file="MainWindowViewModel.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.UI
{
    using System.Windows;
    using CommunityToolkit.Mvvm.ComponentModel;

    public class MainWindowViewModel : ObservableObject
    {
        private WindowState currentWindowState = WindowState.Normal;
        private WindowStyle currentWindowStyle = WindowStyle.SingleBorderWindow;
        private ResizeMode currentResizeMode = ResizeMode.CanResize;
        private bool isTopmost;
        private Visibility currentVisibility = Visibility.Visible;

        public WindowState CurrentWindowState { get => this.currentWindowState; set => this.SetProperty(ref this.currentWindowState, value); }

        public WindowStyle CurrentWindowStyle { get => this.currentWindowStyle; set => this.SetProperty(ref this.currentWindowStyle, value); }

        public ResizeMode CurrentResizeMode { get => this.currentResizeMode; set => this.SetProperty(ref this.currentResizeMode, value); }

        public bool IsTopmost { get => this.isTopmost; set => this.SetProperty(ref this.isTopmost, value); }

        public Visibility CurrentVisibility { get => this.currentVisibility; set => this.SetProperty(ref this.currentVisibility, value); }

        public void OnPlay()
        {
            // Hide before changes
            this.CurrentVisibility = Visibility.Collapsed;

            // Make topmost, maximized, remove style and set resize to none
            this.IsTopmost = true;
            //this.CurrentWindowState = WindowState.Maximized;
            //this.CurrentWindowStyle = WindowStyle.None;
            //this.CurrentResizeMode = ResizeMode.NoResize;

            // Show after changes
            this.CurrentVisibility = Visibility.Visible;
        }

        public void OnStop()
        {
            this.IsTopmost = false;
            this.CurrentWindowState = WindowState.Normal;
            this.CurrentWindowStyle = WindowStyle.SingleBorderWindow;
            this.CurrentResizeMode = ResizeMode.CanResize;
        }
    }
}
