// <copyright file="INotifier.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Shared
{
    using System;
    using MudBlazor;

    public interface INotifier
    {
        /// <summary>
        /// The event invoked when the notifier has notified.
        /// </summary>
        event Action<string, Severity> Notified;
    }
}
