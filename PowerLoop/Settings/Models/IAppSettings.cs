// <copyright file="IAppSettings.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Settings.Models
{
    using System.Collections.Generic;

    public interface IAppSettings
    {
        int DefaultInterval { get; set; }

        List<ILoopItem> LoopItems { get; set; }
    }
}