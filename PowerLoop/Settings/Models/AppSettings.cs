// <copyright file="AppSettings.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Settings.Models
{
    using System.Collections.Generic;

    public class AppSettings : IAppSettings
    {
        public int DefaultInterval { get; set; }

        public List<ILoopItem> LoopItems { get; set; }
    }
}
