// <copyright file="SnackBus.razor.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Shared
{
    using System;
    using Microsoft.AspNetCore.Components;
    using MudBlazor;
    using PowerLoop.Logging;
    using PowerLoop.Play;
    using PowerLoop.Settings;

    public partial class SnackBus : IDisposable
    {
        [Inject]
        private ISnackbar Snackbar { get; set; }

        [Inject]
        private IAppLogger Logger { get; set; }

        [Inject]
        private IPlayViewModel PlayViewModel { get; set; }

        [Inject]
        private ISettingsViewModel SettingsViewModel { get; set; }

        /// <inheritdoc/>
        public void Dispose()
        {
            this.Logger.Notified -= this.Notify;
            this.PlayViewModel.Notified -= this.Notify;
            this.SettingsViewModel.Notified -= this.Notify;
        }

        protected override void OnInitialized()
        {
            this.Logger.Notified += this.Notify;
            this.PlayViewModel.Notified += this.Notify;
            this.SettingsViewModel.Notified += this.Notify;
        }

        private void Notify(string message, Severity severity)
        {
            this.Snackbar.Add(message, severity);
        }
    }
}
