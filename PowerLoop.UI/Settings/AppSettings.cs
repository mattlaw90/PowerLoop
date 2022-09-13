// <copyright file="AppSettings.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.UI.Settings
{
    using System.Collections.Generic;

    public class AppSettings
    {
        public int DefaultInterval { get; set; }

        public List<LoopItem> LoopItems { get; set; }
    }
}
