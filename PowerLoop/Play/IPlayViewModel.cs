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

    public interface IPlayViewModel : INotifyPropertyChanged
    {
        ILoopItem CurrentItem { get; set; }

        bool IsPlaying { get; set; }

        List<ILoopItem> Items { get; set; }

        event Action<ILoopItem> Cycling;

        event Action<string, Severity> Notified;

        bool OnTryStop(KeyEventArgs? args);

        void Start();

        void Stop();
    }
}