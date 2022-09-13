// <copyright file="SettingsViewModel.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.UI.Settings
{
    using System.Collections.Generic;
    using CommunityToolkit.Mvvm.ComponentModel;
    using MudBlazor;
    using PowerLoop.UI.Settings.Commands;
    using PowerLoop.UI.Settings.Queries;

    public class SettingsViewModel : ObservableObject
    {
        private readonly GetSettings getSettings;
        private readonly SaveSettings saveSettings;
        private readonly ISnackbar snackbar;
        private AppSettings appSettings;

        public SettingsViewModel(
            GetSettings getSettings,
            SaveSettings saveSettings)
        {
            this.getSettings = getSettings;
            this.saveSettings = saveSettings;
            // this.snackbar = snackbar;
        }

        public List<LoopItem> LoopItems { get; } = new List<LoopItem>();

        public void OnGet()
        {
            this.appSettings = this.getSettings.Execute();

            this.LoopItems.Clear();
            this.LoopItems.AddRange(this.appSettings.LoopItems);
        }

        public void OnSave()
        {
            if (this.appSettings != null)
            {
                var path = this.saveSettings.Execute(this.appSettings);

                this.snackbar.Add($"Settings save to: {path}");
            }
        }
    }
}
