// <copyright file="Config.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.AppConfig
{
    public class Config : IConfig
    {
        /// <inheritdoc/>
        public string AppSettingsPath { get; set; }

        /// <inheritdoc/>
        public string LogPath { get; set; }

        /// <inheritdoc/>
        public string VirtualHost { get; set; }
    }
}
