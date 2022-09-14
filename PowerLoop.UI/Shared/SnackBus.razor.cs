// <copyright file="SnackBus.razor.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.UI.Shared
{
    using System;
    using Microsoft.AspNetCore.Components;
    using MudBlazor;
    using PowerLoop.UI.Logging;
    using PowerLoop.UI.Play;
    using PowerLoop.UI.Settings;

    public partial class SnackBus : IDisposable
    {
        [Inject]
        private ISnackbar Snackbar { get; set; }

        [Inject]
        private AppLogger Logger { get; set; }

        [Inject]
        private PlayViewModel PlayViewModel { get; set; }

        [Inject]
        private SettingsViewModel SettingsViewModel { get; set; }

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
