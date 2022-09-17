// <copyright file="IPlayViewModel.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Play
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Input;
    using MudBlazor;
    using PowerLoop.Settings;

    public interface IPlayViewModel
    {
        LoopItem CurrentItem { get; set; }

        bool IsPlaying { get; set; }

        List<LoopItem> Items { get; set; }


        event Action<LoopItem> Cycling;

        event Action<string, Severity> Notified;

        bool OnTryStop(KeyEventArgs? args);

        void Start();

        void Stop();
    }
}