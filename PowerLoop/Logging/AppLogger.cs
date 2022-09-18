// <copyright file="AppLogger.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.Logging
{
    using System;
    using System.IO;
    using MudBlazor;
    using PowerLoop.AppConfig;

    public class AppLogger : IAppLogger
    {
        private readonly IConfig config;

        /// <inheritdoc/>
        public event Action<string, Severity> Notified;

        public AppLogger(IConfig config)
        {
            this.config = config;
        }

        public void Log(Exception ex)
        {
            // Create log file if doesn't exist
            // Create the PowerLoop folder if it doesn't already exist
            FileInfo file = new (this.config.AppSettingsPath);
            file?.Directory?.Create();

            // Add to log file
            using (var writer = File.AppendText(this.config.LogPath))
            {
                writer.WriteLine($"{DateTime.Now}\t{ex.Message}");
            }

            this.Notified?.Invoke($"Error! {ex.Message}", Severity.Error);
        }
    }
}
