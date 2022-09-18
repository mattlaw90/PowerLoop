// <copyright file="ISettingsViewModel.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Settings
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using MudBlazor;
    using PowerLoop.Settings.Models;
    using PowerLoop.Shared;

    public interface ISettingsViewModel : INotifier, INotifyPropertyChanged
    {
        int DefaultInterval { get; set; }

        List<ILoopItem> LoopItems { get; }

        event Action<string, Severity> Notified;

        void OnAdd(ILoopItem loopItem);

        void OnDelete(ILoopItem loopItem);

        void OnGet();

        void OnSave();
    }
}