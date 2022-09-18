// <copyright file="IConfig.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.AppConfig
{
    /// <summary>
    /// Defines the app configuration.
    /// </summary>
    public interface IConfig
    {
        /// <summary>
        /// Gets or sets the path to save settings to.
        /// </summary>
        string AppSettingsPath { get; set; }

        /// <summary>
        /// Gets or sets the path to log to.
        /// </summary>
        string LogPath { get; set; }

        /// <summary>
        /// Gets or sets the virtual host name.
        /// </summary>
        string VirtualHost { get; set; }
    }
}