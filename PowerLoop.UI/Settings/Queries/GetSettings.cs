// <copyright file="GetSettings.cs" company="Matt Law">
// Copyright (c) Matt Law. All rights reserved.
// </copyright>

namespace PowerLoop.UI.Settings.Queries
{
    using System;
    using System.IO;
    using System.Text.Json;
    using PowerLoop.UI.Logging;

    public class GetSettings
    {
        private readonly Config config;
        private readonly AppLogger appLogger;

        public GetSettings(Config config, AppLogger appLogger)
        {
            this.config = config;
            this.appLogger = appLogger;
        }

        public AppSettings? Execute()
        {
            try
            {
                // Return list items parsed from file
                var file = File.ReadAllText(this.config.AppSettingsPath);

                var appSettings = JsonSerializer.Deserialize<AppSettings>(file);

                return appSettings;
            }
            catch (Exception ex)
            {
                this.appLogger.Log(ex);
            }

            return null;
        }
    }
}
