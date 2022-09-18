// <copyright file="IAppLogger.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Logging
{
    using System;
    using MudBlazor;
    using PowerLoop.Shared;

    public interface IAppLogger : INotifier
    {
        event Action<string, Severity> Notified;

        void Log(Exception ex);
    }
}