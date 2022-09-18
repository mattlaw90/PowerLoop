// <copyright file="SettingsViewModel.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Settings
{
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using CommunityToolkit.Mvvm.ComponentModel;
    using MudBlazor;
    using PowerLoop.Settings.Commands;
    using PowerLoop.Settings.Models;
    using PowerLoop.Settings.Queries;

    public class SettingsViewModel : ObservableObject, ISettingsViewModel
    {
        private readonly IGetSettings getSettings;
        private readonly ISaveSettings saveSettings;
        private AppSettings appSettings;
        private int defaultInterval;

        public SettingsViewModel(
            IGetSettings getSettings,
            ISaveSettings saveSettings)
        {
            this.getSettings = getSettings;
            this.saveSettings = saveSettings;
        }

        public event Action<string, Severity> Notified;

        public List<ILoopItem> LoopItems { get; } = new List<ILoopItem>();

        public int DefaultInterval { get => this.defaultInterval; set => this.SetProperty(ref this.defaultInterval, value); }

        public void OnGet()
        {
            if (this.getSettings.Execute() is AppSettings settings)
            {
                this.appSettings = settings;

                this.LoopItems.Clear();
                this.LoopItems.AddRange(this.appSettings.LoopItems.OrderBy(i => i.Order));

                this.DefaultInterval = this.appSettings.DefaultInterval;
            }
        }

        public void OnSave()
        {
            // Create a new appsettings if not previously retrieved
            if (this.appSettings == null)
            {
                this.appSettings = new AppSettings()
                {
                    DefaultInterval = this.defaultInterval,
                    LoopItems = this.LoopItems,
                };
            }
            else
            {
                this.appSettings.DefaultInterval = this.DefaultInterval;
                this.appSettings.LoopItems = this.LoopItems;
            }

            var path = this.saveSettings.Execute(this.appSettings);

            this.Notified?.Invoke($"Settings saved in: {path}", Severity.Success);
        }

        public void OnAdd(ILoopItem loopItem)
        {
            this.LoopItems.Add(loopItem);
        }

        public void OnDelete(ILoopItem loopItem)
        {
            this.LoopItems.Remove(loopItem);
        }
    }
}
