// <copyright file="ISettingsViewModel.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Settings
{
    using System;
    using System.Collections.Generic;
    using MudBlazor;

    public interface ISettingsViewModel
    {
        int DefaultInterval { get; set; }

        List<LoopItem> LoopItems { get; }

        event Action<string, Severity> Notified;

        void OnAdd(LoopItem loopItem);

        void OnDelete(LoopItem loopItem);

        void OnGet();

        void OnSave();
    }
}