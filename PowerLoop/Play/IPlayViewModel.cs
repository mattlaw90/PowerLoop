// <copyright file="IPlayViewModel.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Play
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel;
    using System.Windows.Input;
    using MudBlazor;
    using PowerLoop.Settings.Models;
    using PowerLoop.Shared;

    public interface IPlayViewModel : INotifyPropertyChanged, INotifier
    {
        ILoopItem CurrentItem { get; set; }

        bool IsPlaying { get; set; }

        List<ILoopItem> Items { get; set; }

        event Action<ILoopItem> Cycling;

        event Action<string, Severity> Notified;

        bool OnTryStop(KeyEventArgs? args);

        bool TryStart();

        void Stop();
    }
}