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
        int StartItem { get; set; }

        int DefaultInterval { get; set; }

        List<ILoopItem> LoopItems { get; }

        event Action<string, Severity> Notified;

        void OnAdd(ILoopItem loopItem);

        void OnDelete(ILoopItem loopItem);

        void OnGet();

        void OnSave();

        /// <summary>
        /// Moves the loop item up in the order - decreases the order value.
        /// </summary>
        /// <param name="loopItem">The item to move up.</param>
        void OnMoveUp(ILoopItem loopItem);

        /// <summary>
        /// Moves the loop item down in the order - increases the order value.
        /// </summary>
        /// <param name="loopItem">The item to move down.</param>
        void OnMoveDown(ILoopItem loopItem);
    }
}